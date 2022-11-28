using Microsoft.AspNetCore.SignalR;

namespace Blazor_Server_SignalR.Hubs
{
    public class HomeHubNew : Hub
    {
        //WebCams
        public async Task EnviarImagen(string imagenU1x, string rol)
        {
            //MANDAR LA ACTUALIZACION
            await Clients.All.SendAsync("RecibirImagen", imagenU1x, rol);
        }

        public async Task EnviarEstado(string user, string msg)
        {
            await Clients.All.SendAsync("RecibirEstado", user, msg);
        }

    }
}
