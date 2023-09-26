using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace U6_w1_d1
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Coniugato { get; set; }
        public string Coniugatostring { get; set; }
        public int NumeroDiFigli { get; set; } = 0;
        public string Mansione { get; set; }
        public bool inserito { get; set; }

        public Dipendente(
            string nome, string cognome, string indirizzo, string codiceFiscale, bool coniugato, int numeroDiFigli, string mansione)
        {
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Coniugato = coniugato;
            NumeroDiFigli = numeroDiFigli;
            Mansione = mansione;
        }

        public Dipendente(int id, string nome, string cognome, string indirizzo, string codiceFiscale, bool coniugato, string coniugatostring, int numeroDiFigli, string mansione)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Coniugato = coniugato;
            Coniugatostring = coniugatostring;
            NumeroDiFigli = numeroDiFigli;
            Mansione = mansione;
            this.inserito = inserito;
        }

        public Dipendente()
        { }

        public List<Dipendente> dipendenti = new List<Dipendente>();

        public string converetStipendio()
        {
            if (Coniugato)
            {
                return Coniugatostring = "è coniugato";
            }
            else
            {
                return Coniugatostring = "non è coniugato";
            }
        }

        public void NuovoDipendente()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string selezione = "Select count(*) from impiegati where CodiceFiscale = @CodiceFiscale1";
                SqlCommand cmd = new SqlCommand(selezione, conn);
                cmd.Parameters.AddWithValue("CodiceFiscale1", CodiceFiscale);
                int codicefiscal = (int)cmd.ExecuteScalar();
                if (codicefiscal == 0)
                {
                    cmd.CommandText = "INSERT INTO impiegati VALUES(@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroDiFigli, @Mansione)";
                    cmd.Parameters.AddWithValue("Nome", Nome);
                    cmd.Parameters.AddWithValue("Cognome", Cognome);
                    cmd.Parameters.AddWithValue("Indirizzo", Indirizzo);
                    cmd.Parameters.AddWithValue("CodiceFiscale", CodiceFiscale);
                    cmd.Parameters.AddWithValue("Coniugato", Coniugato);
                    cmd.Parameters.AddWithValue("NumeroDiFigli", NumeroDiFigli);
                    cmd.Parameters.AddWithValue("Mansione", Mansione);
                    int inserimentoEffettuato = cmd.ExecuteNonQuery();
                    inserito = true;
                }
                else { inserito = false; }
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }

        public void ListaDipendenti()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM impiegati ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Id = Convert.ToInt32(sqlDataReader["IdImpiegati"].ToString());
                Nome = sqlDataReader["Nome"].ToString();
                Cognome = sqlDataReader["Cognome"].ToString();
                Indirizzo = sqlDataReader["Indirizzo"].ToString();
                CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                Coniugato = Convert.ToBoolean(sqlDataReader["Coniugato"].ToString());
                Coniugatostring = converetStipendio();
                NumeroDiFigli = Convert.ToInt32(sqlDataReader["NumeroDiFigli"].ToString());
                Mansione = sqlDataReader["Mansione"].ToString();

                Dipendente dipendente = new Dipendente(Id, Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, Coniugatostring, NumeroDiFigli, Mansione);
                dipendenti.Add(dipendente);
            }

            conn.Close();
        }
    }
}