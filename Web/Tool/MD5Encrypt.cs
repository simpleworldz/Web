using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
  public  class MD5Encrypt
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptString(string str)
        {
            //以UTF-16获取byte[]
            //byte[] by = Encoding.Unicode.GetBytes(str);
            //以UTF-8获取byte[]
            byte[] by = Encoding.UTF8.GetBytes(str);
            MD5 md5 = MD5.Create();
            byte[] by2 = md5.ComputeHash(by);
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < by2.Length; i++)
            {
                strb.Append(by2[i].ToString("X"));
            }
            return strb.ToString();



        }
    }
}
