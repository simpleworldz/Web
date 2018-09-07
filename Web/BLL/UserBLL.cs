using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Tool;

namespace BLL
{
  public  class UserBLL
    {
        UserDAL dal = new UserDAL();
        /// <summary>
        /// 判断登入名和密码是否正确
        /// </summary>
        /// <param name="loginName">登入名</param>
        /// <param name="password">密码</param>
        /// <returns>登入是否成功</returns>
        public string NameAndPasswordIsTrueOrNot(string loginName, string password)
        {
          User user = dal.GetUserByLoginName(loginName);
            if (user!=null)
            { 
                if (MD5Encrypt.EncryptString(password)==user.Password)
                {
                    return "登入成功！";
                }
                return "密码错误！";
            }
            return "用户名错误！";
        }
    }
}
