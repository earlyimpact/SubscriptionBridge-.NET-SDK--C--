using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Resources;
using System.Globalization;
using System.Threading;


partial class UI : System.Web.UI.MasterPage
{


    public void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
        }

    }
    public UI()
    {
        Load += Page_Load;
    }

}

