using Entities;
using Microsoft.AspNetCore.SignalR;
using Services;

namespace OnlineChat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private MessagesService _messagesService;

        public ChatHub(MessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        public async Task SendMessage(string userId, string message, string myId)
        {
            Message dbMessage = new()
            {
                Messages = message,
                ReceiverId = userId,
                SenderId = myId,

            };
            _messagesService.AddMessage(dbMessage);
            await Clients.User(userId).SendAsync("ReceiveMessage", userId, message, myId);
        }
    }
}
