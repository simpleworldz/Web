using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace WebApplication1
{
    public class VerifyPage:Page
    {
        public void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"]==null)
            {
                Session["InitialUrl"] =Request.Url;
                //Response.Write("<script language='javascript'>alert('成功');</script>");
                //Response.Write("<script>window.onload=function() {alert('成功')}</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session["InitialUrl"] = null;
            }
        }
    }
}