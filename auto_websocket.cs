using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace RutonyChat
{
    public class Script
    {
        public class LA_integration : WebSocketBehavior
        {
            protected override void OnError(ErrorEventArgs e)
            {
                RutonyBot.SayToWindow("error = " + e.Message);
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                try
                {
                    RutonyBot.SayToWindow("data = " + e.Data);
                }
                catch (Exception ex)
                {
                    RutonyBot.SayToWindow("Ошибка: " + ex);
                }
            }
        }


        public void InitParams(string param)
        {
            RutonyBot.SayToWindow("Test script connected");

            var wss = new WebSocketServer(5157);
            wss.AddWebSocketService<LA_integration>("/");
            wss.Start();
        }

        public void Closing()
        {
            RutonyBot.SayToWindow("Test script disconnected");
        }

        public void NewMessage(string site, string name, string text, bool system)
        {

        }

        public void NewMessageEx(string site, string name, string text, bool system, Dictionary<string, string> Params)
        {

        }

        public void NewAlert(string site, string typeEvent, string subplan, string name, string text, float donate, string currency, int qty)
        {

        }
    }
}