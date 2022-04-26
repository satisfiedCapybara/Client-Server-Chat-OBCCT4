using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{

  class myThread
  {
    public Thread thread;
    public Socket handler;
    public List<Socket> myClientList;
    public myThread(string name, Socket theListeningSocket, List<Socket> theClientList)
    {
      thread = new Thread(this.func);
      thread.Name = name;
      myClientList = theClientList;
      thread.Start(theListeningSocket);
    }

    string GetSocketInfo()
    {
      if (handler != null)
      {
        return null;
      }
      else
      {
        return handler.ToString();
      }

    }

    void func(object listeningSocket)
    {

      Socket listenSocket = listeningSocket as Socket;

      StringBuilder builder = new StringBuilder("");
      int bytes = 0;
      int kol_bytes = 0;
      byte[] data = new byte[255];

      handler = listenSocket.Accept();
      myClientList.Add(handler);

      while (true)
      {
        builder = new StringBuilder("");

        do
        {
          bytes = handler.Receive(data);
          builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
          kol_bytes += bytes;
        }
        while (handler.Available > 0);

        foreach (var socket in myClientList)
        {
          byte[] aBytes = Encoding.UTF8.GetBytes(builder.ToString());

          socket.Send(aBytes);
        }

        if (builder.ToString() == "shutdown")
        {
          myClientList.Remove(handler);
          handler.Shutdown(SocketShutdown.Both);
          handler.Close();
          break;
        }
      }
    }
  }

  class Program
  {
    static int port = 8005;
    static void Main(string[] args)
    {
      List<Socket> clientThreadList = new List<Socket>();

      String Host = Dns.GetHostName();
      Console.WriteLine("Comp name = " + Host);
      IPAddress[] IPs;
      IPs = Dns.GetHostAddresses(Host);
      foreach (IPAddress ip1 in IPs)
        Console.WriteLine(ip1);

      IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

      Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      try
      {
        listenSocket.Bind(ipPoint);

        listenSocket.Listen(10);

        for (; ; )
        {
          myThread aMyThread = new myThread("sa", listenSocket, clientThreadList);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
