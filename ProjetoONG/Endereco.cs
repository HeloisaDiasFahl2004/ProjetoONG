using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Endereco
    {
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco(string l,string cep,string comp, int num, string b, string c,string est)
        {
            this.Logradouro = l;
            this.CEP = cep;  
            this.Complemento = comp;
            this.Numero = num;
            this.Bairro = b;
            this.Cidade = c;
            this.Estado = est;
        }
        public Endereco()
        {

        }
        public Endereco CadastrarEndereco()
        {
            Console.Write("Logradouro: ");
            string l = Console.ReadLine();

            Console.Write("CEP: ");
            string cep = Console.ReadLine();

            Console.Write("Complemento: ");
            string comp = Console.ReadLine();

            Console.Write("Número: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Bairro: ");
            string b = Console.ReadLine();

            Console.Write("Cidade: ");
            string c = Console.ReadLine();

            Console.Write("Estado: ");
            string est =Console.ReadLine();

            Endereco e = new Endereco(l,cep,comp,num,b,c,est);
            return e;
        }
    }
}
