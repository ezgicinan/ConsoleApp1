using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO; //StreamReader ve StreamWriter siniflari için
using System.Linq;

public class Client
{

    const int PORT_NO = 5000;
    const string SERVER_IP = "192.168.1.21"; //127.0.0.1

    public static void Main(string[] args) {

        try 
        {            
            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            Console.WriteLine("Connecting.....");
            
            //---data to send to the server---               
            Console.Write("Enter the string to be transmitted, write '<EOF>' at the en of your message and enter: ");
            String str = Console.ReadLine();
            NetworkStream nwStream = client.GetStream();
            
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(str);
            
            Console.WriteLine("Transmitting.....");
            
            //---send the text to the connected TcpServer---
            Console.WriteLine("Sending from Client to the Server: " + str);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            
            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received from Server: " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();         
            
            //Close
            nwStream.Close();
            client.Close();
        }
        catch (Exception e){
            Console.WriteLine("Error..... " + e.StackTrace);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.ReadLine();

    }
}
