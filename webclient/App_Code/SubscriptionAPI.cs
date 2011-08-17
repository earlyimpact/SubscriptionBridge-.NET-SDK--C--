using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using SubscriptionAPI;

namespace SubscriptionBridge
{

    public class SubscriptionAPI
    {

        public string GetTimeRequest()
        {

            StringBuilder strXML = new StringBuilder();

            strXML.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            strXML.AppendLine("<GetTimeRequest>");
            strXML.AppendLine("<Username>" + "" + "</Username>");
            strXML.AppendLine("</GetTimeRequest>");

            string RequestXML = strXML.ToString();

            XMLExchange XMLExchangeObj = new XMLExchange();
            XMLExchangeObj.url = "https://www.subscriptionbridge.com/Subscriptions/Service2.svc/GetTimeRequest";

            string strResponse = null;
            strResponse = XMLExchangeObj.sendXMLPOST(RequestXML);

            string strReturn = XMLExchangeObj.xEval(strResponse, "GetTimeResponse/CurrentTime");

            XMLExchangeObj = null;


            return strReturn;

        }

    }

}

