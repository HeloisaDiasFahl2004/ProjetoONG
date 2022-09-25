using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class BD
    {
        string Conexao = "Data Source = 'localhost\\SQLSERVER'; Initial Catalog = ONG;User Id = sa; Password= sqlservermeu;";
        
        public BD()
        {
          
        }
       public string Caminho()
        {
            return Conexao;
        }
    }
}
