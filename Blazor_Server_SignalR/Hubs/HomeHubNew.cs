using Microsoft.AspNetCore.SignalR;

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
        private static string ER { get; set; } = "";
        private static string SU1 { get; set; } = "0";
        private static string SU2 { get; set; } = "0";
        private static string SU3 { get; set; } = "0";
        private static string SU4 { get; set; } = "0";
        private static int D1 { get; set; } = 0;
        private static int D2 { get; set; } = 0;
        private static int D3 { get; set; } = 0;
        private static int D4 { get; set; } = 0;

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

        public async Task EnviarBarcos(string barco1, string barco2)
        {
            B1 = barco1;
            B2 = barco2;

            await Clients.All.SendAsync("RecibirBarcos", barco1, barco2);
        }

        public async Task ConsutarBarcos()
        {
            string b1 = B1;
            string b2 = B2;

            await Clients.All.SendAsync("RecibirCBarcos", b1, b2);
        }

        public async Task EnviarDados(string usr, string val1, string val2)
        {
            V1 = val1;
            V2 = val2;

            await Clients.All.SendAsync("RecibirDados", usr, val1, val2);
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

        public async Task EnviarEvento(string evento)
        {
            ER = evento;

            await Clients.All.SendAsync("RecibirEvento", evento);
        }

        public async Task ConsultarEv()
        {
            string evento = ER;

            await Clients.All.SendAsync("RecibirCEvento", evento);
        }
    }
}
