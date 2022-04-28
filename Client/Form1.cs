using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
  public partial class Form1 : Form
  {
    private int myPort = 8005;
    private string myAddress = "127.0.0.1";
    private IPEndPoint myIpPoint;
    private Socket mySocket;
    private Thread myRecieveThread;


    void RecieveMessage(object theListenSocket)
    {
      StringBuilder aBuilder = new StringBuilder("");
      Socket aListenSocket = theListenSocket as Socket;

      byte[] aData = new byte[256];
      int aBytes = 0;

      for ( ; ; )
      {
        aBuilder = new StringBuilder("");

        do
        {
          aBytes = aListenSocket.Receive(aData, aData.Length, 0);
          aBuilder.Append(Encoding.UTF8.GetString(aData, 0, aBytes));
        }
        while (aListenSocket.Available > 0);

        OutputTextField.Text += DateTime.Now.ToShortTimeString() + "\n" +"Message: " + aBuilder.ToString() + "\n\n";
      }


    }
    public Form1()
    {
      InitializeComponent();
      myIpPoint = new IPEndPoint(IPAddress.Parse(myAddress), myPort);
      mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      mySocket.Connect(myIpPoint);

      myRecieveThread = new Thread(this.RecieveMessage);
      myRecieveThread.Start(mySocket);
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      byte[] aData = Encoding.Unicode.GetBytes(InputTextField.Text);

      mySocket.Send(aData);
    }
  }
}
