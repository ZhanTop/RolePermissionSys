using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace My.RolePermission.Common
{
    public class ValidateCode
    {
        public ValidateCode()
        {

        }
        /// <summary>
        /// 验证码最大长度
        /// </summary>
        public int MaxLength
        {
            get
            {
                return 10;
            }
        }
        /// <summary>
        /// 验证码最小长度
        /// </summary>
        public int MinLength
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 生产验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];   //随机成员数组
            int[] validateNums = new int[length];
            //生产起始序列值
            int seekSeek=unchecked((int)DateTime.Now.Ticks);//unchecked：溢出不检测
            Random seekRand = new Random(seekSeek);//计算随机数起始值的实例
            int beginSeek= seekRand.Next(0, Int32.MaxValue - length * 10000);//返回指定范围内的随机数 
            int[] seek = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seek[i] = beginSeek;
            }

            int pownum =(int)Math.Pow(10, length);//Math.Pow(x,y) x的y次幂 
            //抽取随机数
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seek[i]);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }

            //生产验证码
            //获取随机数为几位数
            //有几位数就从该数第几位截取一个数字
            for (int i = 0; i < length; i++)
            {
                string randNum= randMembers[i].ToString();
                int l= randNum.Length;
                Random rd = new Random();
                int rs= rd.Next(0, l - 1);
                validateNums[i]=int.Parse(randNum.Substring(rs,1));
            }
            string v = "";
            //拼接验证码
            for (int i = 0; i < length; i++)
            {
                v += validateNums[i].ToString();
            }
            return v;
        }

        /// <summary>
        /// 验证码图片的宽度
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        public int GetImageWidth(int length)
        {
            return (int)(length * 12.0);
        }

        /// <summary>
        /// 验证码图片的高度
        /// </summary>
        /// <returns></returns>
        public double GetImageHeight()
        {
            return 22.5;
        }

        /// <summary>
        /// 根据验证码生产图片
        /// </summary>
        /// <param name="ValidateCode"></param>
        /// <param name="context">要输出的page对象</param>
        public void CreateValidateGraphic(string ValidateCode,HttpContext context)
        {
            //初始化图片大小
            Bitmap image = new Bitmap(GetImageWidth(ValidateCode.Length), (int)GetImageHeight());
            Graphics g = Graphics.FromImage(image);//从指定的image创建新的graphic
            try
            {
                //生成随机生成器
                Random rand = new Random();
                //清除绘画图并以指定填充背景色
                g.Clear(Color.White);
                //画图的干扰线  affect:
                for(int i=0;i<25;i++)
                {
                    int x1 = rand.Next(image.Width);
                    int y1 = rand.Next(image.Height);
                    int x2 = rand.Next(image.Width);
                    int y2 = rand.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0,0,image.Width,image.Height),Color.Blue,Color.DarkRed,1.2f,true);
                g.DrawString(ValidateCode, font, brush, 3, 2);//绘制文本

                //绘制图片前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(rand.Next()));
                }
                //绘制图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                MemoryStream stream = new MemoryStream();
                image.Save(stream,ImageFormat.Jpeg);//以指定格式保存到指定的流中
                //输出图片流
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(stream.ToArray());
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        //C# MVC 升级版
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}
