using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFramework;
using OpenServer.Protocol;

namespace OpenServer.Handler
{
    //所有处理需要继承该接口用于消息分发
    public interface HandlerInterface
    {
        void ClientClose(UserToken token, string error);

        //   void ClientConnect(UserToken token);

        void MessageReceive(UserToken token, SocketModel message);
    }
}
