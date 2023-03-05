using System;
using NetMQ;
using NetMQ.Sockets;

namespace PublisherConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://127.0.0.1:8888");

                string line;
    
                do
                {
                    line = Console.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        publisher
                            .SendMoreFrame("COMMAND")
                            .SendFrame(line);
                    }
                } while (!string.IsNullOrEmpty(line));
            }
        }
    }
}