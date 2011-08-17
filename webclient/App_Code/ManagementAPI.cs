using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace SubscriptionBridge
{

    public class ManagementAPI
    {

        public string AddMeteredRequest(string User, string Token, string Guid, string Amount, string Memo, string LinkID)
        {

            StringBuilder strXML = new StringBuilder();

            strXML.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            strXML.AppendLine("<AddMeteredRequest>");
            strXML.AppendLine("<Username>" + User + "</Username>");
            strXML.AppendLine("<Token>" + Token + "</Token>");
            strXML.AppendLine("<Guid>" + Guid + "</Guid>");
            strXML.AppendLine("<Amount>" + Utilities.removeInvalidXML(Amount) + "</Amount>");
            strXML.AppendLine("<Memo>" + Utilities.removeInvalidXML(Memo) + "</Memo>");
            strXML.AppendLine("<RefName>" + Utilities.removeInvalidXML(LinkID) + "</RefName>");
            strXML.AppendLine("</AddMeteredRequest>");

            return strXML.ToString();

        }

    }

}
