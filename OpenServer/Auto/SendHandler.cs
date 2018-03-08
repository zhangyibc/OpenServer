using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFramework;
using OpenServer.Protocol;
using NetFramework.Auto;

namespace OpenServer.Auto
{
    class SendHandler
    {
        private byte type;

        public byte Type
        {
            get { return type; }
            set { type = value; }
        }
        private int area;

        public int Area
        {
            get { return area; }
            set { area = value; }
        }

        //创建一个socket消息体
        public SocketModel CreateSocketModel(byte type, int area, int command, object message)
        {
            return new SocketModel(type, area, command, message);
        }

        //通过token发送消息
        public void write(UserToken token, int command)
        {
            write(token, command, null);
        }
        public void write(UserToken token, int command, object message)
        {
            write(token, Area, command, message);
        }
        public void write(UserToken token, int area, int command, object message)
        {
            write(token, Type, Area, command, message);
        }
        public void write(UserToken token, byte type, int area, int command, object message)
        {
            byte[] value = SocketModelEncoding.encode(CreateSocketModel(type, area, command, message));
            value = LengthEncoding.encode(value);
            token.write(value);
        }
    }
}
