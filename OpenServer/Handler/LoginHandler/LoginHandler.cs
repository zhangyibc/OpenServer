using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProtocol;
using GameProtocol.DTO;
using OpenServer.Auto;
using OpenServer.Protocol;
using NetFramework;

namespace OpenServer.Handler.LoginHandler
{
    class LoginHandler:SendHandler,HandlerInterface
    {
        public LoginHandler()
        {
            this.Type = GameProtocol.Protocol.TYPE_LOGIN;
        }
        //登陆时客户端断开链接如何处理
        public void ClientClose(UserToken token, string error)
        {
            
        }

        //消息体子模块分发
        public void MessageReceive(UserToken token, SocketModel message)
        {
            Console.WriteLine("Login");
            //switch (message.command)
            //{
            //    case LoginProtocol.LOGIN_CREQ:
            //        Login(token, message.GetMessage<AccountInfoDTO>());
            //        break;
            //    case LoginProtocol.REG_CREQ:
            //        Register(token, message.GetMessage<AccountInfoDTO>());
            //        break;
            //}
        }

        //消息体命令处理
        public void Login(UserToken token, AccountInfoDTO value)
        {
            //TODO 判断是否登陆成功
            int result = 1;
            write(token, LoginProtocol.LOGIN_SRES, result);
        }

        //消息体命令处理
        public void Register(UserToken token, AccountInfoDTO value)
        {
            //TODO 判断是否注册成功
            int result = 1;
            write(token, LoginProtocol.REG_SRES, result);
        }
    }
}
