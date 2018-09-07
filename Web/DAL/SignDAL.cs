using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Model;
using System.Data;

namespace DAL
{
  public  class SignDAL
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="signName">用户名</param>
        /// <param name="signPwd">密码</param>
        /// <returns>受影响的行数</returns>
        public int SignUserDAL(string signName,string signPwd)
        {
            string sql = "insert into User(Name,Password) values(@Name,@Password)";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@Name", signName), new SQLiteParameter("@Password", signPwd));
        }
        /// <summary>
        /// 获取所有用户名
        /// </summary>
        /// <returns>包含所又用户名的List</returns>
        public List<string> GetAllUserName()
        {
            string sql = "select Name from User where DelFlag=0";
            List<string> names = new List<string>();
            using (SQLiteDataReader sdr=SqliteHelper.ExecuteReader(sql))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        names.Add(sdr[0].ToString());
                    }
                }
            }
            return names;
           
        }
    }
}
