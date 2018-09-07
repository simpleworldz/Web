using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Sign : System.Web.UI.Page
    {
        //提示信息
        protected string Msg { get; set; }
        //输入的信息
        protected string Name { get; set; }
        protected string Pwd1 { get; set; }
        protected string Pwd2 { get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                Name = Request["nname"];
                Pwd1 = Request["npwd1"];
                Pwd2 = Request["npwd2"];
                string vCode = Request["nvcode"];
                //判断验证码
                if (vCode == Session["ValidateCode"].ToString())
                {

                    //判断是否为空
                    if (Name != "" && Pwd1 != "" && Pwd2 != "")
                    {

                        //判断两次输入的密码是否相同
                        if (Pwd1 == Pwd2)
                        {   //用正则表达式判断密码是否符合不少于8个字符，且含有数字，字母，字符中的其中
                            //两种，还有空格要求。
                            if (PasswordIsNotTooSimple(Pwd1))
                            {
                                SignBLL signBll = new SignBLL();
                                Msg = signBll.IsUserNameRepeat(Name, Pwd1);
                            }

                        }
                        else
                        {
                            Msg = "两次输入密码不同！";
                            Pwd1 = "";
                            Pwd2 = "";
                        }
                    }
                    else
                    {
                        Msg = "用户名和密码都不能为空";
                    }
                }
                else
                {
                    Msg = "验证码不正确！";
                }
            }
        }
        

        private bool PasswordIsNotTooSimple(string pwd1)
        {
            if (pwd1.Length<8)
            {
                Msg = "密码长度不能小于8！";
                return false;
            }
            else if (Regex.IsMatch(pwd1, @"\s"))
            {
                Msg = "密码不能包含空字符！";
                return false;
            }
            else if(IsHasTwoCharStyle(pwd1))
            {
                Msg = "密码至少包含字母，数字，字符中的两种！";
                return false;
            }
            else
            {
                return true;

            }
           
         
        }
        /// <summary>
        /// 判断是否含两种以上字节
        /// </summary>
        /// <param name="pwd1">密码</param>
        /// <returns>含两种以上--false，否则--true</returns>
        private bool IsHasTwoCharStyle(string pwd1)
        {
            int num = 0;
            if (Regex.IsMatch(pwd1, "\\d"))
            {
                num += 1;
            }
            if (Regex.IsMatch(pwd1,"[a-zA-Z]"))
            {
                num += 1;
            }
            if (Regex.IsMatch(pwd1, "[^a-zA-Z0-9]"))

            {
                num += 1;
            }
            if (num>=2)
            {
                return false;
            }
            return true;
        }
    }
}