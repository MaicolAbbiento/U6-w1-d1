using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U6_w1_d1
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string CodiceFiscale { get; set; }
        public string PeriodoPagamento { get; set; }
        public decimal Pagamenti { get; set; }
        public bool Stipendio { get; set; }
        public int IdImpiegati { get; set; }
        public string stipendiostring { get; set; }

        public Pagamento()
        { }

        public List<Pagamento> List = new List<Pagamento>();

        public Pagamento(string codiceFiscale, decimal pagamenti, string stipendio)
        {
            CodiceFiscale = codiceFiscale;
            Pagamenti = pagamenti;
            stipendiostring = stipendio;
        }

        public Pagamento(int id, string periodoPagamento, decimal pagamenti, bool stipendio, int idImpiegati)
        {
            Id = id;
            PeriodoPagamento = periodoPagamento;
            Pagamenti = pagamenti;
            Stipendio = stipendio;
            IdImpiegati = idImpiegati;
        }

        public void converetStipendio()
        {
            if (stipendiostring == "stipendio")
            {
                Stipendio = true;
            }
            else
            {
                Stipendio = false;
            }
        }

        public void faiPagamento()
        {
            converetStipendio();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string selezione = "Select idImpiegati from impiegati where CodiceFiscale = @CodiceFiscale1";
                SqlCommand cmd = new SqlCommand(selezione, conn);
                cmd.Parameters.AddWithValue("@CodiceFiscale1", CodiceFiscale);
                SqlDataReader sqlDataReader;
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    IdImpiegati = Convert.ToInt32(sqlDataReader["Idimpiegati"].ToString());
                }
                PeriodoPagamento = DateTime.Now.ToString("dd/MM/yyyy");
                sqlDataReader.Close();
                sqlDataReader.Dispose();
                if (IdImpiegati != 0)
                {
                    cmd.CommandText = "INSERT INTO stipendi VALUES(@PeriodoPagamento, @Pagamenti, @Stipendio, @IdImpiegati)";
                    cmd.Parameters.AddWithValue("PeriodoPagamento", PeriodoPagamento);
                    cmd.Parameters.AddWithValue("Pagamenti", Pagamenti);
                    cmd.Parameters.AddWithValue("Stipendio", Stipendio);
                    cmd.Parameters.AddWithValue("IdImpiegati", IdImpiegati);

                    int inserimentoEffettuato = cmd.ExecuteNonQuery();
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }

        public void ListaPagamenti()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM stipendi ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Id = Convert.ToInt32(sqlDataReader["Idstipendi"].ToString());
                PeriodoPagamento = sqlDataReader["PeriodoPagamento"].ToString();
                Pagamenti = Convert.ToDecimal(sqlDataReader["Pagamento"].ToString());
                Stipendio = Convert.ToBoolean(sqlDataReader["Stipendio"].ToString());
                IdImpiegati = Convert.ToInt32(sqlDataReader["IdImpiegati"].ToString());
                Pagamento Pagamento = new Pagamento(Id, PeriodoPagamento, Pagamenti, Stipendio, IdImpiegati);
                List.Add(Pagamento);
            }

            conn.Close();
        }
    }
}