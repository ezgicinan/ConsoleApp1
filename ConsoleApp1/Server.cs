
using System;
using System.Collections.Generic;
using System.Text;
using System.IO; //StreamReader ve StreamWriter siniflari için
using System.Net.Sockets; // Socket, TcpListener ve NetworkStrem siniflari için
using System.Net;
using System.Net.Http;

public class Server
{
    const int PORT_NO = 5000; //Set the TcpListener on port 5000.
    const string SERVER_IP = "192.168.1.21"; //127.0.0.1

    public static void Main(string [] args)
    {
        TcpListener listener = null;

        try
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            listener = new TcpListener(localAdd, PORT_NO);

            //Start listening for client requests.
            Console.WriteLine("Listening...");
            listener.Start();

            Console.WriteLine("The server is running at port 5000...");
            StringBuilder myCompleteMessage = new StringBuilder();
            
            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();
                          
            Console.WriteLine("Connected!");
            
            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            
            byte[] buffer = new byte[client.ReceiveBufferSize];
            string dataReceived = null;
            int bytesRead = 0;
            
            //Take the current time info
            DateTime now = DateTime.Now;
            
            while (true)
            {
                //---read incoming stream---
                bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                dataReceived += Encoding.ASCII.GetString(buffer, 0, bytesRead);
            
                if (dataReceived.IndexOf("<EOF>") > -1)
                    break;
            }
            
            Console.WriteLine("Received from Client: " + dataReceived);
            dataReceived += "  " + now.ToString();
            
            byte[] byToSend = ASCIIEncoding.ASCII.GetBytes(dataReceived);
            
            //---write back the text to the client---
            Console.WriteLine("Sending back : " + dataReceived);
            nwStream.Write(byToSend, 0, byToSend.Length);
            
            //Shutdown and end connection
            client.GetStream().Close();
            client.Close();
            
            // Stop listening for new clients.
            listener.Stop();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\nHit enter to continue...");     
        Console.ReadLine();
    }
}
