using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;
using Model;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="loginName">用户输入的用户名（登入名）</param>
        /// <returns>所查询到的用户</returns>
        public User GetUserByLoginName(string loginName)
        {
            string sql = "select * from User where DelFlag=0 and Name=@Name";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@Name", loginName));
            User user = null;
            //判断是否有数据
            if (dt.Rows.Count>0)
            {
                
                user = RowToUser(dt.Rows[0]);
            }
            return user;

        }
        //把关系型数据转化成对象---关系转对象
        private User RowToUser(DataRow dr)
        {
            User user1 = new User();
            user1.Name = dr["Name"].ToString();
            user1.Password = dr["Password"].ToString();
            return user1;

        }
    }
}
