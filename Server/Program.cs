using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
  class Program
  {
    static void Main(string[] args)
    {
      int aPort = 8005;
      List<Socket> aСlientThreadList = new List<Socket>();

      String Host = Dns.GetHostName();
      Console.WriteLine("Host: " + Host);
      IPAddress[] IPs;
      IPs = Dns.GetHostAddresses(Host);

      foreach ( IPAddress ip1 in IPs )
      {
        Console.WriteLine(ip1);
      }

      IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), aPort);
      Socket aListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

      try
      {
        aListenSocket.Bind(ipPoint);
        aListenSocket.Listen(10);

        for ( ; ; )
        {
          ClientHandlerThread aMyThread = new ClientHandlerThread(aListenSocket, aСlientThreadList);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
