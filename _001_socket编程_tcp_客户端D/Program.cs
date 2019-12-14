using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _001_socket编程_tcp_客户端D
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、创建socket
            Socket tcpClient = new  Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //2、发起连接请求
            IPAddress ipaddress = IPAddress.Parse("10.10.10.224");//可以讲一个字符串的ip地址转化成一个ipaddress的对象
            EndPoint point = new IPEndPoint(ipaddress,7788);
            tcpClient.Connect(point);//通过ip和端口号定位一个连接到服务器端

            //3、接收服务器消息
            byte[] data = new byte[1024];
            int length =  tcpClient.Receive(data);//length表示接受到了多少哥数据
            string message = Encoding.UTF8.GetString(data,0,length);//只转化length长度字符串
            Console.WriteLine(message);
            //4、向服务器端发送消息
            string message2 = Console.ReadLine();
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));
            Console.ReadKey();
        }
    }
}
