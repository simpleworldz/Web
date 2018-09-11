<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign.aspx.cs" Inherits="WebApplication1.Sign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        用户名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" name="nname" value="<%=Name %>"/> <br />
        密码：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="password" name="npwd1" value="<%=Pwd1 %>"/> <br />
        确认密码：<input type="password" name="npwd2"  value="<%=Pwd2 %>"/> <br />
        验证码：<input type="text" name="nvcode" size="7" /><img src="VCode.ashx" alt="验证码" /><br />
        手机验证？邮箱验证？</div>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <input type="submit"  value="注册" /><a href="login.aspx" title="login">登入</a>
 <h4 style="color:red"><%=Msg%> </h4>  
    </form>
</body>
</html>
