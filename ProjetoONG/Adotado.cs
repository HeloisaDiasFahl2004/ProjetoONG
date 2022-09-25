using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Adotado
    {
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome{ get; set; }

        public Adotado()
        {

        }
        public Adotado( string f, string r, char s, string n)
        {
          
            this.Familia = f;
            this.Raca = r;
            this.Sexo = s;
            this.Nome = n;
        }
        public Adotado CadastrarAdotado()
        {
            Console.WriteLine(" >>> INICIANDO CADASTRO ADOTADO <<< ");
            Thread.Sleep(1000);

            Console.Write("Família: ");
            string f = Console.ReadLine();

            Console.Write("Raça: ");
            string r = Console.ReadLine();

            Console.Write("Sexo: (M/F)");
            char s = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Nome: ");
            string n = Console.ReadLine();

            Adotado adotado = new Adotado(f,r,s,n);
            return adotado;
        }
    }
}
