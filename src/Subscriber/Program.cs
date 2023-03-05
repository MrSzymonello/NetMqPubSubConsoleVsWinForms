using System;
using NetMQ;
using NetMQ.Sockets;

namespace Subscriber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var subscriber = new SubscriberSocket())
            {
                subscriber.Connect("tcp://127.0.0.1:8888");
                subscriber.Subscribe("COMMAND");

                while (true)
                {
                    string topic = subscriber.ReceiveFrameString();
                    string command = subscriber.ReceiveFrameString();
                    
                    Console.WriteLine($"Command: '{command}', topic: '{topic}'.");
                    
                    if (command.ToLower() == "quit")
                    {
                        break;
                    }
                }
            }
        }
    }
}