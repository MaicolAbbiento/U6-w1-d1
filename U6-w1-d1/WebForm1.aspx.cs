using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U6_w1_d1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pagamento dipendenti = new Pagamento();
                dipendenti.ListaPagamenti();
                Repeater1.DataSource = dipendenti.List;
                Repeater1.DataBind();
            }
        }
    }
}