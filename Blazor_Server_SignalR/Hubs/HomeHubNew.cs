﻿using Microsoft.AspNetCore.SignalR;

namespace Blazor_Server_SignalR.Hubs
{
    public class HomeHubNew : Hub
    {
        private static string mapax { get; set; } = "";
        private static string desCap { get; set; } = "";
        private static string B1 { get; set; } = "";
        private static string B2 { get; set; } = "";
        private static string V1 { get; set; } = "1";
        private static string V2 { get; set; } = "1";
        private static string ER { get; set; } = "M10";
        private static string SU1 { get; set; } = "0";
        private static string SU2 { get; set; } = "0";
        private static string SU3 { get; set; } = "0";
        private static string SU4 { get; set; } = "0";
        private static int D1 { get; set; } = 0;
        private static int D2 { get; set; } = 0;
        private static int D3 { get; set; } = 0;
        private static int D4 { get; set; } = 0;


        private static void ReiniciarDatosServer() 
        {
            mapax = "";
            desCap = "";
            B1 = "";
            B2  = "";
            V1  = "1";
            V2  = "1";
            ER  = "M10";
            SU1  = "0";
            SU2  = "0";
            SU3  = "0";
            SU4  = "0";
            D1 = 0;
            D2 = 0;
            D3  = 0;
            D4 = 0;
        }


        public async Task EnviarRecursos(int usr, string msg)
        {
            
            await Clients.All.SendAsync("RecibirRecursos", usr, msg);
        }

        public async Task EnviarNoti(int quien, int Noti, int turno)
        {
            switch (quien)
            {
                case 1:
                    D1 = Noti;
                    break;

                case 2:
                    D2 = Noti;
                    break;

                case 3:
                    D3 = Noti;
                    break;

                case 4:
                    D4 = Noti;
                    break;
            }

            //MANDAR LA ACTUALIZACION
            await Clients.All.SendAsync("RecibirNoti", quien, Noti, turno);
        }

        public async Task ConsultarNotis()
        {
            string msg = $"{D1};{D2};{D3};{D4};";

            //MANDAR LA ACTUALIZACION
            await Clients.Caller.SendAsync("RecibirCNotis", msg);
        }

        public async Task ConsultarPath()
        {
            string msg = $"{SU1};{SU2};{SU3};{SU4};";

            //MANDAR LA ACTUALIZACION
            await Clients.Caller.SendAsync("RecibirCPath", msg);
        }

        public async Task EnviarPath(string quien, string path)
        {
            switch (quien)
            {
                case "1":
                    SU1 = path;
                    break;

                case "2":
                    SU2 = path;
                    break;

                case "3":
                    SU3 = path;
                    break;

                case "4":
                    SU4 = path;
                    break;
            }

            //MANDAR LA ACTUALIZACION
            await Clients.All.SendAsync("RecibirPath", quien, path);
        }


        public async Task EnviarEstado(string usr, string msg)
        {
            await Clients.All.SendAsync("RecibirEstado", usr, msg);
        }

        public async Task EnviarBarco(int usr, string barco)
        {

            await Clients.All.SendAsync("RecibirBarco", usr, barco);
        }

        public async Task EnviarDados(string usr, string val1, string val2, string listo)
        {
            V1 = val1;
            V2 = val2;

            await Clients.All.SendAsync("RecibirDados", usr, val1, val2, listo);
        }

        public async Task ConsultarDados()
        {
            string v1 = V1;
            string v2 = V2;

            await Clients.All.SendAsync("RecibirCDados", v1, v2);
        }

        public async Task EnviarMapa(string usr, string mapa)
        {
            mapax = mapa;

            await Clients.All.SendAsync("RecibirMapa", usr, mapa);
        }

        public async Task ConsultarMap()
        {
            string mapa = mapax;

            await Clients.All.SendAsync("RecibirCMapa", mapa);
        }

        public async Task EnviarMov(string des)
        {
            desCap = des;

            await Clients.All.SendAsync("RecibirMov", des);
        }

        public async Task ConsultarMov()
        {
            string des = desCap;

            await Clients.All.SendAsync("RecibirCMov", des);
        }

        public async Task EnviarEvento(int rol, string evento)
        {

            await Clients.All.SendAsync("RecibirEvento", rol, evento);
        }

        public async Task ConsultarEv()
        {
            string evento = ER;

            await Clients.All.SendAsync("RecibirCEvento", evento);
        }
    }
}
