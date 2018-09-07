using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
 
    public partial class Login : System.Web.UI.Page
    {
        protected string Msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                //判断验证码----待补充
                string name = Request["uname"];
                string password = Request["upwd"];
                string vCode = Request["vcode"];
                //判断验证码
                if (vCode == Session["ValidateCode"].ToString())
                {


                    if (name != "" && password != "")
                    {
                        //Model.User user = new Model.User()
                        //{
                        //    Name = Request["uname"],
                        //    Password = Request["upwd"]
                        //};
                        BLL.UserBLL userBLL = new BLL.UserBLL();
                        Msg = userBLL.NameAndPasswordIsTrueOrNot(name, password);
                        if (Msg == "登入成功！")
                        {
                            Model.User user = new Model.User() { Name = name, Password = password };
                            Session["User"] = user + "88394";
                            HttpCookie nameCookie = new HttpCookie("name");
                            nameCookie.Value = name;
                            HttpCookie pwdCookie = new HttpCookie("Pwd");
                            pwdCookie.Value = password;
                            Response.Cookies.Add(nameCookie);
                            Response.Cookies.Add(pwdCookie);
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else
                    {
                        Msg = "用户名和密码不能空！";
                    }
                }
                else
                {
                    Msg = "验证码错误！";
                }

            }
        }
    }
}