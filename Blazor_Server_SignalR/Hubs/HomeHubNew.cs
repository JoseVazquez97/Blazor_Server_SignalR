﻿using Microsoft.AspNetCore.SignalR;

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

        public async Task EnviarBarcos(string usr, string barco1, string barco2) 
        {
            await Clients.All.SendAsync("RecibirBarco", usr, barco1, barco2);
        }


        public async Task EnviarDados(string user, string val1, string val2) 
        {
            await Clients.Others.SendAsync("RecibirDados", user, val1, val2);
        }
    }
}
