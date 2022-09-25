using System;
using System.Data.SqlClient;

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
       
       

    }
}
