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
    static int port = 8005; // порт сервера
    static string address = "127.0.0.1"; // адрес сервера
    static IPEndPoint ipPoint;
    Socket socket;
    StringBuilder builder;
    Thread thread;


    void func(object listeningSocket)
    {
      StringBuilder builder = new StringBuilder();

      Socket listenSocket = listeningSocket as Socket;

      byte[] data = new byte[256];
      int bytes = 0;

      for (; ; )
      {
        builder = new StringBuilder("");

        do
        {
          bytes = listenSocket.Receive(data, data.Length, 0);
          builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
        }
        while (listenSocket.Available > 0);
        this.OutputTextField.Text += DateTime.Now.ToShortTimeString() + "\n" +"Сообщение: " + builder.ToString() + "\n\n";
      }


    }
    public Form1()
    {
      InitializeComponent();
      ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
      //создаем сокет
      socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

      // подключаемся к удаленному хосту
      socket.Connect(ipPoint);
      builder = new StringBuilder();

      thread = new Thread(this.func);
      thread.Start(socket);
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      string message = InputTextField.Text;
      byte[] data = Encoding.Unicode.GetBytes(message);

      //посылаем сообщение
      socket.Send(data);
      // готовимся получить ответ
      data = new byte[256]; // буфер для ответа
      int bytes = 0; // количество полученных байт
                      // получаем ответ'

      builder = new StringBuilder("");
    }
  }
}
