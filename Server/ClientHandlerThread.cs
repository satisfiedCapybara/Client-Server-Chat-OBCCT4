using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
  class ClientHandlerThread
  {
    public ClientHandlerThread(Socket theListeningSocket, List<Socket> theClientSocketList)
    {
      myThread = new Thread(this.Handle);
      myClientSocketList = theClientSocketList;
      myThread.Start(theListeningSocket);
    }

    void Handle(object listeningSocket)
    {
      Socket aListenSocket = listeningSocket as Socket;
      StringBuilder aBuilder = new StringBuilder("");
      int aBytes = 0;
      int aNumberBytes = 0;
      byte[] data = new byte[255];

      mySocketHandler = aListenSocket.Accept();
      myClientSocketList.Add(mySocketHandler);

      while (true)
      {
        aBuilder = new StringBuilder("");

        do
        {
          aBytes = mySocketHandler.Receive(data);
          aBuilder.Append(Encoding.Unicode.GetString(data, 0, aBytes));
          aNumberBytes += aBytes;
        }
        while (mySocketHandler.Available > 0);

        foreach (var socket in myClientSocketList)
        {
          byte[] anArrayBytes = Encoding.UTF8.GetBytes(aBuilder.ToString());

          socket.Send(anArrayBytes);
        }

        if (aBuilder.ToString() == "shutdown")
        {
          myClientSocketList.Remove(mySocketHandler);
          mySocketHandler.Shutdown(SocketShutdown.Both);
          mySocketHandler.Close();
          break;
        }
      }
    }

    private Thread myThread;
    private Socket mySocketHandler;
    private List<Socket> myClientSocketList;
  }
}
