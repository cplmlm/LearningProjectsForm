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
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string HttpPostWebService(string url, string strInput)
        {
            string result = string.Empty;//返回值
            //string param = string.Empty;//请求参数
            byte[] bytes = null;
            HttpWebRequest request = null;
            Stream writer = null;
            string responseString = string.Empty;//返回内容
            // SOAP格式内容，参数为：xml
            StringBuilder param = new StringBuilder();
            param.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://service.ws.domain.jkjczx.ohms.zjcdjk.cn/\">\r\n");
            param.Append("<soapenv:Header/>\r\n");
            param.Append("<soapenv:Body>\r\n");
            param.Append("<ser:SynApplyInfo>\r\n");
            param.Append("<arg0><![CDATA[");
            param.Append(strInput);
            param.Append("]]></arg0>\r\n");
            param.Append("</ser:SynApplyInfo>\r\n</soapenv:Body>\r\n</soapenv:Envelope>");
            try
            {
                //param = $"strInput={strInput}";//接收参数名称
                bytes = Encoding.UTF8.GetBytes(param.ToString());
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
