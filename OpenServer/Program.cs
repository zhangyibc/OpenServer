using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFramework;
using NetFramework.Auto;
using OpenServer.Protocol;
using LuaInterface;
using OpenServer.Auto;

namespace OpenServer
{
    class Program
    {
        //Server启动
        static void Main(string[] args)
        {
            ServerStart openServer = new ServerStart(9000);
            openServer.center = new HandlerCenter();

            //使用SocketModel协议传输信息
            //openServer.decode = SocketModelEncoding.decode;
            //openServer.encode = SocketModelEncoding.encode;

            //使用OpenModel协议传输信息
            //openServer.decode = OpenEncoding.decode;
            //openServer.encode = OpenEncoding.encode;

            //使用LuaModel
            openServer.decode = LuaModelEncoding.decode;
            openServer.encode = LuaModelEncoding.encode;

            openServer.Start(23333);
            Console.WriteLine("服务器启动成功");
            while (true) { }
        }
    }
}
