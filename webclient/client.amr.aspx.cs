using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using SubscriptionBridge;
using SubscriptionAPI;

partial class _client_amr : BasePage
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
        string strGuid = Guid.Text;
        string strAmount = Amount.Text;
        string strMemo = Memo.Text;
        string strLinkID = LinkID.Text;


        ManagementAPI ManagementAPIObj = new ManagementAPI();
        string RequestXML = null;
        RequestXML = ManagementAPIObj.AddMeteredRequest(strMerchantUsername, strToken, strGuid, strAmount, strMemo, strLinkID);
        ManagementAPIObj = null;

        XMLExchange XMLExchangeObj = new XMLExchange();
        XMLExchangeObj.url = "https://www.subscriptionbridge.com/Management/Service3.svc/AddMeteredRequest";

        string strResponse = null;
        strResponse = XMLExchangeObj.sendXMLPOST(RequestXML);
        XMLExchangeObj = null;



        if (strResponse.IndexOf("Success") != -1)
        {
            //Dim strParam As String
            //strParam = XMLExchangeObj.xEval(strResponse, "AddMeteredResponse/Ack")
            //Results.Text = strParam

            Results.Text = strResponse;


        }
        else
        {
            Results.Text = strResponse;

        }


    }


}
