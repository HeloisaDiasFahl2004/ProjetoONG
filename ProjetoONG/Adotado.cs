using System;
using System.Data.SqlClient;
using System.Threading;

namespace ProjetoONG
{
    internal class Adotado
    {
        public int CHIP { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }

        public Adotado()
        {

        }
        public Adotado(string f, string r, char s, string n)
        {

            this.Familia = f;
            this.Raca = r;
            this.Sexo = s;
            this.Nome = n;
        }
        public void CadastrarAdotado()
        {
            Console.WriteLine(" >>> INICIANDO CADASTRO ADOTADO <<< ");
            Thread.Sleep(1000);

            Console.Write("Família: ");
            this.Familia = Console.ReadLine();

            Console.Write("Raça: ");
            this.Raca = Console.ReadLine();

            Console.Write("Sexo: (M/F)");
            this.Sexo = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Nome: ");
            this.Nome = Console.ReadLine();

;
        } // cadastrar adotado
       
    }
}
