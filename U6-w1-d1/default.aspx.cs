﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U6_w1_d1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dipendente dipendenti = new Dipendente();
                dipendenti.ListaDipendenti();
                Repeater1.DataSource = dipendenti.dipendenti;
                Repeater1.DataBind();
            }
        }
    }
}