using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Adotante
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public Adotante()
        {

        }
        public Adotante(string n, string cpf, char sexo, DateTime dn, Endereco e, string t)
        {
            this.Nome = n;
            this.CPF = cpf;
            this.Sexo = sexo;
            this.DataNascimento = dn;
            this.Endereco = e;
            this.Telefone = t;
        }
        public Adotante CadastrarAdotante()
        {
           
            Console.WriteLine(" >>> INICIANDO CADASTRO ADOTANTE <<< ");
            Thread.Sleep(1000);

            Console.Write("Nome: ");
            string n = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Sexo: (M/F)");
            char s = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Data Nascimento: ");
            DateTime dn = DateTime.Parse(Console.ReadLine());
          
           //endereço
            Endereco e = new Endereco();
            e.CadastrarEndereco();

            Console.Write("Telefone: ");
            string t = Console.ReadLine();

            Adotante adotante = new Adotante(n, cpf, s, dn, e, t);
            return adotante;
        }
      
    }
    
}
