using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace SubscriptionBridge
{

    public class AuthenticationAPI
    {

        public string VerifyAccountCredentialsRequest(string User, string Token, string Email, string Password)
        {

            StringBuilder strXML = new StringBuilder();

            strXML.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            strXML.AppendLine("<VerifyAccountCredentialsRequest>");
            strXML.AppendLine("<Username>" + User + "</Username>");
            strXML.AppendLine("<Token>" + Token + "</Token>");
            strXML.AppendLine("<Email>" + Utilities.removeInvalidXML(Email) + "</Email>");
            strXML.AppendLine("<Password>" + Utilities.removeInvalidXML(Password) + "</Password>");
            strXML.AppendLine("</VerifyAccountCredentialsRequest>");

            return strXML.ToString();

        }

    }

}
