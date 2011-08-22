using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace SubscriptionBridge
{

    /// <summary>
    /// Custom base page used for all web forms.
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {



        protected override void OnError(System.EventArgs e)
        {
            //// Redirect to Generic Error
            Response.Redirect("/500.aspx", false);

        }

    }

}
