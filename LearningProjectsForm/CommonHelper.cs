using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LearningProjectsForm
{
    public class CommonHelper
    {
        /// <summary>
        /// 调用WebService接口
        /// </summary>
        /// <param name="url">请求接口地址</param>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        public static string HttpPostWebService(string url, string param)
        {
            string result = string.Empty;//返回值
            byte[] bytes = null;
            HttpWebRequest request = null;
            Stream writer = null;
            string responseString = string.Empty;//返回内容
            try
            {
                bytes = Encoding.UTF8.GetBytes(param);
                //解决Framwork4.0调用Web接口报错：基础连接已经关闭：发送时发生错误
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)3072 | (SecurityProtocolType)768 | SecurityProtocolType.Tls;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/xml;charset=UTF-8";
                request.ContentLength = bytes.Length;
                request.Timeout = 10000; // 设置请求超时时间为10秒
                using (writer = request.GetRequestStream())
                {
                    writer.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
