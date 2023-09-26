using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U6_w1_d1
{
    public partial class faiUnpagamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errore1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int money = 0;
            try
            {
                money = Convert.ToInt32(soldi.Text);
            }
            catch
            {
                errore1.Visible = true;
                errore1.InnerHtml = "si prega di inserire un valore numerico senza inserire valute";
            }
            if (DropDownList1.SelectedItem.Value != "")
            {
                if (!errore1.Visible)
                {
                    Pagamento pagamento = new Pagamento(CodiceFiscale.Text, Convert.ToInt32(soldi.Text), DropDownList1.SelectedItem.Value);
                    pagamento.faiPagamento();
                }
            }
            else
            {
                errore2.InnerHtml = "selezionare un opzione";
            }
        }
    }
}