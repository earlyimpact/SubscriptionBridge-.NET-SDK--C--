<%@ Page Title="" Language="C#" MasterPageFile="~/UI.master" AutoEventWireup="false"
    CodeFile="client.otp.aspx.cs" Inherits="_client_otp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Onetime Payment</h1>
    <%
        string var_ReturnURL = "http://localhost/testStores/v4.5.1/sb/example/onetimepayment.asp"; 
        string var_Amount = "10.00";
        string var_APIKey = "8699D8F7EFD640CB8ECD9C4EBAA871D9";
        string var_Signature = SubscriptionBridge.Utilities.HashToken(var_Amount + "|" + var_ReturnURL, var_APIKey); 
    %>
    <script type="text/javascript" language="javascript">
        var _noconflict = 0;
        var SubscriptionBridge = function () {
            if (_noconflict == 0) {

                var Transaction = new OnetimePayment();
                Transaction.URL = "http://www.subscriptionbridge.com/v2/OnetimePayment";
                Transaction.ID = "mydiv";
                Transaction.Guid = "TDUTUT2920126648";
                Transaction.Description = 'Extra Bandwith';
                Transaction.Amount = '<%=var_Amount%>';
                Transaction.Currency = 'EUR';
                Transaction.Language = 'en';
                Transaction.ReturnURL = '<%=var_ReturnURL%>';
                Transaction.Signature = '<%=var_Signature%>';
                Transaction.IsProrated = 'True';
                Transaction.IsRecurring = 'True';
                Transaction.PassThrough = 'val,val2,val3,val4';

                Transaction.Open();
            }
            _noconflict = 1;
        };
    </script>
    <div id="mydiv">
    </div>
    <script type="text/javascript" language="javascript">
        (function (d, t) { var g = d.createElement(t), s = d.getElementsByTagName(t)[0]; g.src = '//www.subscriptionbridge.com/v2/subscriptionbridge.min.js'; g.onreadystatechange = SubscriptionBridge; g.onload = SubscriptionBridge; s.parentNode.insertBefore(g, s) } (document, 'script'));
    </script>
</asp:Content>
