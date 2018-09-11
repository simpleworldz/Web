<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        用户名：<input type="text" name="uname" value="<%string name = Request.Cookies["name"]== null ? "" : Request.Cookies["name"].Values.ToString() ;
               %><%=name %>" /> 
        <br />&nbsp;&nbsp;
        密码：<input type="password" name ="upwd" value="<%string pwd = Request.Cookies["pwd"]!=null?Request.Cookies["pwd"].Values.ToString():"";
               %><%=pwd %>" />
        <br />
        验证码：<input type="text" name="vcode"size="7"/>
        <img src="VCode.ashx" alt="看不清 换一个" id="img1" onclick=" getElementById('img1').src='VCode.ashx?'+new Date().getTime();"/>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="submit" value="登录" /> <a title="sign-up" href="sign.aspx">注册</a>
      <h4 style="color:red"><%=Msg %></h4>
    </div>
    </form>
</body>
</html>
