using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace myFirstServer
{
    class Program
    {
        static int minPort = 1;
        static int maxPort = 65536;
        static Socket client;
        static NetworkStream netstream;
        
        [STAThread]
        static void Main(string[] args)
        {
            int port;
            Console.Title = "Server";
            DisplayHeader();
            port = GetValidPort();

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            TcpListener tcplistener = new TcpListener(ipAddress, port);
        }

        

        private static int GetValidPort()
        {
            bool validResponse = false;
            int userInteger = 0;

            while (!validResponse)
            {

                DisplayHeader();
                Console.WriteLine("The server needs a port number to listen on");
                Console.Write($"Please enter port number as an integer between ({minPort} - {maxPort}): ");

                if (int.TryParse(Console.ReadLine(), out userInteger))
                {
                    if (userInteger >= minPort && userInteger <= maxPort)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        DisplayHeader();
                        Console.WriteLine($"Please enter a valid integer between {minPort} and {maxPort}!");
                        DisplayContinuePrompt();
                        Console.Clear();
                    }
                }
                else
                {
                    DisplayHeader();
                    Console.WriteLine($"Please only enter a whole number between {minPort} and {maxPort}!");
                    DisplayContinuePrompt();
                }

            }
            return userInteger;
        }

        private static void DisplayContinuePrompt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("TCP Server");
            Console.WriteLine();
        }
    }
}
