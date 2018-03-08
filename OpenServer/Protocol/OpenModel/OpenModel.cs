using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenServer.Protocol
{
    public class OpenModel
    {
        /// <summary>
        /// 协议号
        /// </summary>
        public int commond { get; set; }
        /// <summary>
        /// 消息体内容
        /// </summary>
        public string parameter { get; set; }
        /// <summary>
        /// 消息体
        /// </summary>
        public byte[] message { get; set; }

        public OpenModel() { }

        public OpenModel(int c, string s, byte[] a)
        {
            this.commond = c;
            this.parameter = s;
            this.message = a;
        }
    }
}
