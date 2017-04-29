using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace websocket
{
    public class wsserver
    {
        public List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();
        public bool open = false;
        
        private Action<int> act;
        public wsserver(Action<int> act) {
            this.act = act;
        }
        public bool isopen() {
            return open;
        }
        public void init(int port)
        {
            FleckLog.Level = LogLevel.Debug;
            
            var server = new WebSocketServer("ws://0.0.0.0:"+port);
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                    act(allSockets.Count());
                };              
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                    act(allSockets.Count());
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    if(websocket.autoback)
                         socket.Send(message);
                };
            });
        }
        public void send(string input) {
            foreach (var socket in allSockets.ToList())
            {
                socket.Send(input);
            }
        }
    }
}