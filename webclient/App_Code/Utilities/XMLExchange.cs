using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Xml;
using System.IO;

namespace SubscriptionAPI
{


    public class XMLExchange
    {

        private string APIurl;
        private string ProxyString;
        private HttpWebRequest RequestObject;

        private HttpWebResponse ResponseObject;
        public string proxy
        {
            get { return this.ProxyString; }
            set { this.ProxyString = value; }
        }

        public string url
        {
            get { return this.APIurl; }
            set { this.APIurl = value; }
        }

        public XMLExchange()
        {
            this.ProxyString = "";
            this.APIurl = "";
        }

        public static bool CheckXMLSuccess(XmlTextReader xtr)
        {
            bool flag1 = false;
            xtr.WhitespaceHandling = WhitespaceHandling.None;
            while (xtr.Read())
            {
                if (xtr.Name != "SUCCESS")
                {
                    continue;
                }
                try
                {
                    flag1 = Convert.ToBoolean(xtr.ReadString());
                }
                catch (Exception generatedExceptionName)
                {
                }
                break; // TODO: might not be correct. Was : Exit While
            }
            return flag1;
        }

        public XmlTextReader sendXML(string XMLtoSend)
        {
            XmlTextReader reader1 = null;
            string text1 = (this.APIurl + "?xml=") + HttpUtility.UrlEncode(XMLtoSend);
            this.RequestObject = (HttpWebRequest)WebRequest.Create(text1);
            this.RequestObject.Accept = "text/xml";
            this.RequestObject.ContentType = "application/x-www-form-urlencoded";
            this.RequestObject.Method = "POST";
            this.RequestObject.Timeout = 10000;
            //Me.RequestObject.Proxy = New WebProxy(Me.ProxyString)
            try
            {
                this.ResponseObject = (HttpWebResponse)this.RequestObject.GetResponse();
                reader1 = new XmlTextReader(this.ResponseObject.GetResponseStream());
            }
            catch (Exception exception1)
            {
                WebException exception2 = new WebException((exception1.Message + " (proxy is: ") + this.ProxyString + ")");
                throw exception2;
            }
            return reader1;
        }


        public string sendXMLPOST(string XMLtoSend)
        {

            string result = "";
            StreamWriter myWriter = null;

            RequestObject = (HttpWebRequest)WebRequest.Create(APIurl);
            RequestObject.Accept = "text/xml";
            RequestObject.ContentType = "text/xml";
            RequestObject.Method = "POST";
            RequestObject.Timeout = 30000;


            try
            {
                myWriter = new StreamWriter(RequestObject.GetRequestStream());
                myWriter.Write(XMLtoSend);
                myWriter.Flush();
                myWriter.Close();

                HttpWebResponse objResponse = (HttpWebResponse)RequestObject.GetResponse();

                StreamReader sr = null;
                sr = new StreamReader(objResponse.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();


            }
            catch (Exception e1)
            {
                result = e1.Message;


            }
            finally
            {
                RequestObject = null;

            }

            RequestObject = null;
            myWriter = null;

            return result;

        }


        public string xEval(string x, string xPath)
        {
            XmlDocument xDocument = new XmlDocument();
            xDocument.LoadXml(x);
            if (xDocument.SelectSingleNode(xPath) == null)
            {
                x = "";
            }
            else
            {
                x = xDocument.SelectSingleNode(xPath).InnerText;
            }
            return x;
        }


    }


}
