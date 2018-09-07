using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Tool;

namespace BLL
{
public     class SignBLL
    {
        //创建SignDAL对象
        SignDAL signDal = new SignDAL();
        UserDAL userDal = new UserDAL();
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="signName">用户名</param>
        /// <param name="signPwd">密码</param>
        /// <returns>注册成功返回“注册成功”，失败则返回“注册失败”</returns>
        public string SignUserBLL(string signName, string signPwd)
        {
            int num = signDal.SignUserDAL(signName,MD5Encrypt.EncryptString(signPwd));
            return num!=1?"注册失败！":"注册成功！";
        }
        /// <summary>
        /// 判断用户名是否重复，如果不重复则注册用户
        /// </summary>
        /// <param name="signName">用户名</param>
        /// <param name="signPwd">密码</param>
        /// <returns>提示字符串</returns>
        public string IsUserNameRepeat(string signName,string signPwd)
        {
            List<string> names = signDal.GetAllUserName();

            foreach (string name in names )
            {
                if (signName==name)
                {
                    return "用户名已存在！";
                }
            }
            return this.SignUserBLL(signName, signPwd);
        }
    }
}
