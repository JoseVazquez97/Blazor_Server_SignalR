using Microsoft.AspNetCore.SignalR;

namespace Blazor_Server_SignalR.Hubs
{
    public class ChatHub : Hub
    {

        public Task EnviarMensaje(string user, string msg) 
        {

            return Clients.All.SendAsync("RecibirMensaje", user, msg);
        }
    }
}
