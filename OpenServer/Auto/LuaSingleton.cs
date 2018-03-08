using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace OpenServer.Auto
{
    public static class LuaSingleton
    {
        private static Lua instance = null;

        public static Lua getInstance()
        {
            if (instance == null)
            {
                instance = new Lua();
            }
            return instance;
        }
    }
}
