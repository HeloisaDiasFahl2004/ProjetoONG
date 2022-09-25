using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Adocao
    {
        public string CPF { get; set; }
        public int CHIP { get; set; }
        public DateTime DataAdocao { get; set; }

        public Adocao()
        {

        }
        public Adocao(string cpf, int chip, DateTime dataAdocao)
        {
            this.CPF = cpf;
            this.CHIP = chip;
            this.DataAdocao = DateTime.Now;
        }
        public void CadastrarAdocao()
        {
            Console.Write("Informe o númedo do CPF: ");
            CPF = Console.ReadLine();

            Console.Write("Informe o número de identificação do animal: ");
            CHIP = int.Parse(Console.ReadLine());

            DataAdocao = DateTime.Now;
        }
        public void VisualizarAdocao()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());

            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CPF, CHIP, DataAdocao FROM Adocao";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                    Console.WriteLine("{0}", reader.GetInt32(1));
                    Console.WriteLine("{0}", reader.GetDateTime(2));

                }
            }
            conexaosql.Close();
        } //SELECT
        public void InserirAdocao(Adocao adocao)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            string sql = $"INSERT INTO Adocao(CPF,CHIP,DataAdocao) VALUES('{adocao.CPF}', " + $"'{adocao.CHIP}','{adocao.DataAdocao}');";
            SqlCommand cmdINSERTadocao = new SqlCommand(sql, conexaosql);
            cmdINSERTadocao.ExecuteNonQuery();
            conexaosql.Close();
        } //INSERT 
       
    }
}
