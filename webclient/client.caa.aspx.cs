using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using SubscriptionBridge;
using SubscriptionAPI;

public partial class _client_caa : BasePage
{
    protected void Button1_Click1(object sender, EventArgs e)
    {

        string strMerchantUsername = null;
        string strMerchantPassword = null;
        string strMerchantKey = null;

        strMerchantUsername = _User.Text;
        strMerchantPassword = _Pass.Text;
        strMerchantKey = _Key.Text;

        //// Hash the Token
        string strToken = Utilities.HashToken(strMerchantPassword, strMerchantKey);

        //// Form
        string strEmail = Email.Text;


        AuthenticationAPI AuthenticationAPIObj = new AuthenticationAPI();
        string RequestXML = null;
        RequestXML = AuthenticationAPIObj.CheckAccountAvailableRequest(strMerchantUsername, strToken, strEmail);
        AuthenticationAPIObj = null;

        XMLExchange XMLExchangeObj = new XMLExchange();
        XMLExchangeObj.url = "https://www.subscriptionbridge.com/Authentication/Service5.svc/CheckAccountAvailableRequest";

        string strResponse = null;
        strResponse = XMLExchangeObj.sendXMLPOST(RequestXML);
        XMLExchangeObj = null;



        if (strResponse.IndexOf("Success") != -1)
        {
            // string strParam = null;
            // strParam = XMLExchangeObj.xEval(strResponse, "CheckAccountAvailableResponse/Ack");
            // Results.Text = strParam;

            Results.Text = strResponse;


        }
        else
        {
            Results.Text = strResponse;

        }


    }

}