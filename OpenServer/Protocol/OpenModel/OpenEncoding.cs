using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenServer.Auto;

namespace OpenServer.Protocol
{
    class OpenEncoding
    {
        /// <summary>
        /// 消息体序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] encode(object value)
        {
            OpenModel model = value as OpenModel;
            ByteArray ba = new ByteArray();

            ba.write(model.commond);
            ba.write(model.parameter);
            ba.write(model.message);

            byte[] result = ba.getBuff();
            ba.Close();
            return result;
        }
        /// <summary>
        /// 消息体反序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object decode(byte[] value)
        {
            ByteArray ba = new ByteArray(value);
            OpenModel model = new OpenModel();

            int commond;
            string parameter;
            byte[] message;

            //从数据中读取 命令 命令内容 消息体 读取和写入的顺序必须保持一致
            ba.read(out commond);
            ba.read(out parameter);
            //命令内容如果为空则该命令无需消息体
            if ( (parameter != "") || (parameter != null))
            {
                //将剩余数据全部读取出来
                ba.read(out message, ba.Length - ba.Position);
            }
            else
            {
                message = new byte[0];
            }

            model.commond = commond;
            model.parameter = parameter;
            model.message = message;

            ba.Close();
            return model;
        }
    }
}
