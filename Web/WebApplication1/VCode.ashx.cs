using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Vcode 的摘要说明
    /// </summary>
    public class VCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //设置返回格式
            context.Response.ContentType = "image/jpeg";
            //产生验证码
            int vCodeLength = 4;
            string vCodeContent = "abcdefghijklmnopqrstuvwxyz0123456789";
            string vCode = "";
            Random r = new Random();
            for (int i = 0; i < vCodeLength; i++)
            {
                vCode += vCodeContent[r.Next(0, vCodeContent.Length)];
            }
            //作图
            context.Session["ValidateCode"] = vCode;
            Bitmap bm = new Bitmap(50, 20);
            Graphics gra = Graphics.FromImage(bm);
            gra.Clear(Color.White);
            gra.DrawRectangle(new Pen(Color.Black), 0, 0, bm.Width - 1, bm.Height - 1);
            gra.DrawString(vCode, new Font("consolas", 14), new SolidBrush(Color.Blue), 0, 0, new StringFormat(StringFormatFlags.LineLimit));
            //保存并输出（返回）
            bm.Save(context.Response.OutputStream, ImageFormat.Jpeg);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}