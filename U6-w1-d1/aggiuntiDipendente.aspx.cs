using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U6_w1_d1
{
    public partial class aggiuntiDipendente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (NumeroFigli.Text != "")
            {
                a = Convert.ToInt32(NumeroFigli.Text);
            };
            Dipendente dipendete = new Dipendente(Nome.Text, Cognome.Text, Indirizzo.Text, CodiceFiscale.Text, coniugato.Checked, a, mansione.Text);
            dipendete.NuovoDipendente();
            if (!dipendete.inserito)
            {
                controll.InnerHtml = "impiegato gia presente nel databese";
            }
        }
    }
}