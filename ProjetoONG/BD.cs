using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

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


        #region Adotante
        public void InserirAdotante(Adotante adotante)
        {
            try
            {
                BD bd = new BD();
                SqlConnection conexaosql = new SqlConnection(bd.Caminho());
                conexaosql.Open();
                string insertAdotante = $"INSERT INTO Adotante(Nome, CPF, Sexo, DataNascimento, Telefone) VALUES('{adotante.Nome}' ," + $"'{adotante.CPF}' , '{adotante.Sexo}' , '{adotante.DataNascimento}'  , '{adotante.Telefone}');";
                var endereco = adotante.Endereco;
                string insertEndereco = $"INSERT INTO Endereco (CPF,Logradouro,CEP,Complemento,Numero,Bairro,Cidade,Estado) VALUES ('{adotante.CPF}' ," + $"'{endereco.Logradouro}' , '{endereco.CEP}' , '{endereco.Complemento}','{endereco.Numero}' , '{endereco.Bairro}' , '{endereco.Cidade}', '{endereco.Estado}')";
                SqlCommand cmdINSERTadotante = new SqlCommand(insertAdotante, conexaosql);
                SqlCommand cmdINSERTendereco = new SqlCommand(insertEndereco, conexaosql);
                cmdINSERTadotante.ExecuteNonQuery();
                cmdINSERTendereco.ExecuteNonQuery();
                conexaosql.Close();
                Console.WriteLine("Adotante inserido com sucesso!");
                Console.ReadKey();
            }
            catch (SqlException e)
            {
                if (e.Number != 2627) // chave duplicada
                    throw;

                Console.WriteLine("CPF já existente");
                Console.ReadKey();

            }

        } // adiciono 1 adotante
        public void VisualizarAdotantes(Adotante adotante)
        {

            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            cmdSELECTadotante.CommandText = "SELECT Nome,a.CPF,Sexo,DataNascimento,Telefone,Logradouro,CEP,Complemento,Numero,Bairro,Cidade,Estado FROM Adotante a inner join Endereco e on e.CPF = a.CPF";
            cmdSELECTadotante.Connection = conexaosql;
            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())//permite o acesso ao banco de dados
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetString(0) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(1) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(2) + "\t");
                    Console.Write("{0}\t", sqlReader.GetDateTime(3) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(4) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(5) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(6) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(7) + "\t");
                    Console.Write("{0}\t", sqlReader.GetInt32(8) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(9) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(10) + "\t");
                    Console.WriteLine("{0}\t", sqlReader.GetString(11) + "\t");

                }
            }
            Console.WriteLine("\nImpressão de Adotantes encerrada!");
            Console.ReadKey();
        } // seleciono todos os adotantes
        public Adotante BuscarAdotante(Adotante adotante)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            Console.Write("Informe o CPF que deseja buscar: ");
            string cpf = Console.ReadLine();


            cmdSELECTadotante.CommandText = "SELECT Nome,a.CPF,Sexo,DataNascimento,Telefone,Logradouro,CEP,Complemento,Numero,Bairro,Cidade,Estado FROM Adotante a  inner join Endereco e on e.CPF = a.CPF WHERE a.CPF=@CPF";
            cmdSELECTadotante.Parameters.AddWithValue("@CPF", cpf);
            cmdSELECTadotante.Connection = conexaosql;

            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetString(0) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(1) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(2) + "\t");
                    Console.Write("{0}\t", sqlReader.GetDateTime(3) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(4) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(5) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(6) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(7) + "\t");
                    Console.Write("{0}\t", sqlReader.GetInt32(8) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(9) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(10) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(11) + "\t");
                }
            }
            Console.WriteLine("\nBusca encerrada!");
            Console.ReadKey();
            conexaosql.Close();
            return adotante;
        } // seleciono 1 adotante específico
        public void AtualizarCampoAdotante()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Informe o campo que deseja editar: 0-Cancelar Edição  1-Nome  2-Sexo  3-Data Nascimento  4-Endereço  5-Telefone ");
            int campo = int.Parse(Console.ReadLine());
            switch (campo)
            {
                case 0:
                    return;
                case 1:
                    SqlCommand cmdUpdateN = new SqlCommand();
                    cmdUpdateN.CommandText = "UPDATE Adotante set Nome = @Nome  WHERE cpf=@CPF;";
                    Console.Write("Informe o novo nome: ");
                    string n = Console.ReadLine();
                    cmdUpdateN.Parameters.AddWithValue("@Nome", n);
                    cmdUpdateN.Parameters.AddWithValue("@CPF", cpf);
                    cmdUpdateN.Connection = conexaosql;
                    cmdUpdateN.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 2:
                    SqlCommand cmdUpdateS = new SqlCommand();
                    cmdUpdateS.CommandText = "UPDATE Adotante set Sexo = @sexo  WHERE cpf=@CPF;";
                    Console.Write("Informe o novo sexo: ");
                    char s = char.Parse(Console.ReadLine());
                    cmdUpdateS.Parameters.AddWithValue("@Sexo", s);
                    cmdUpdateS.Parameters.AddWithValue("@CPF", cpf);
                    cmdUpdateS.Connection = conexaosql;
                    cmdUpdateS.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 3:
                    SqlCommand cmdUpdateD = new SqlCommand();
                    cmdUpdateD.CommandText = "UPDATE Adotante set DataNascimento = @DataNascimento  WHERE cpf=@CPF;";
                    Console.Write("Informe a nova Data Nascimento: ");
                    DateTime d = DateTime.Parse(Console.ReadLine());
                    cmdUpdateD.Parameters.AddWithValue("@DataNascimento", d);
                    cmdUpdateD.Parameters.AddWithValue("@CPF", cpf);
                    cmdUpdateD.Connection = conexaosql;
                    cmdUpdateD.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 4:

                    Console.Write("Informe o que deseja editar: 1-Logradouro  2-CEP  3-Complemento  4-Numero  5-Bairro  6-Cidade  7-Estado ");
                    int r = int.Parse(Console.ReadLine());
                    switch (r)
                    {
                        case 1:
                            SqlCommand cmdUpdateE = new SqlCommand();
                            cmdUpdateE.CommandText = "UPDATE Endereco set Logradouro = @Logradouro WHERE cpf=@CPF;";
                            Console.Write("Informe o novo Logradouro: ");
                            string lNovo = Console.ReadLine();
                            cmdUpdateE.Parameters.AddWithValue("@Logradouro", lNovo);
                            cmdUpdateE.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateE.Connection = conexaosql;
                            cmdUpdateE.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 2:
                            SqlCommand cmdUpdateCEP = new SqlCommand();
                            cmdUpdateCEP.CommandText = "UPDATE Endereco set CEP = @CEP  WHERE cpf=@CPF;";
                            Console.Write("Informe o novo CEP: ");
                            string cepNovo = Console.ReadLine();
                            cmdUpdateCEP.Parameters.AddWithValue("@CEP", cepNovo);
                            cmdUpdateCEP.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateCEP.Connection = conexaosql;
                            cmdUpdateCEP.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 3:
                            SqlCommand cmdUpdateCOMP = new SqlCommand();
                            cmdUpdateCOMP.CommandText = "UPDATE Endereco set Complemento = @Complemento  WHERE cpf=@CPF;";
                            Console.Write("Informe o novo Complemento: ");
                            string compNovo = Console.ReadLine();
                            cmdUpdateCOMP.Parameters.AddWithValue("@Complemento", compNovo);
                            cmdUpdateCOMP.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateCOMP.Connection = conexaosql;
                            cmdUpdateCOMP.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 4:
                            SqlCommand cmdUpdateNUM = new SqlCommand();
                            cmdUpdateNUM.CommandText = "UPDATE Endereco set Numero = @Numero  WHERE cpf=@CPF;";
                            Console.Write("Informe o novo Numero: ");
                            int numNovo = int.Parse(Console.ReadLine());
                            cmdUpdateNUM.Parameters.AddWithValue("@Numero", numNovo);
                            cmdUpdateNUM.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateNUM.Connection = conexaosql;
                            cmdUpdateNUM.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 5:
                            SqlCommand cmdUpdateB = new SqlCommand();
                            cmdUpdateB.CommandText = "UPDATE Endereco set Bairro = @Bairro  WHERE cpf=@CPF;";
                            Console.Write("Informe o novo Bairro: ");
                            string bairroNovo = Console.ReadLine();
                            cmdUpdateB.Parameters.AddWithValue("@Bairro", bairroNovo);
                            cmdUpdateB.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateB.Connection = conexaosql;
                            cmdUpdateB.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 6:
                            SqlCommand cmdUpdateC = new SqlCommand();
                            cmdUpdateC.CommandText = "UPDATE Endereco set Cidade = @Cidade  WHERE cpf=@CPF;";
                            Console.Write("Informe a nova Cidade: ");
                            string CidadeNovo = Console.ReadLine();
                            cmdUpdateC.Parameters.AddWithValue("@Cidade", CidadeNovo);
                            cmdUpdateC.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateC.Connection = conexaosql;
                            cmdUpdateC.ExecuteNonQuery();
                            conexaosql.Close();
                            break;
                        case 7:
                            SqlCommand cmdUpdateEST = new SqlCommand();
                            cmdUpdateEST.CommandText = "UPDATE Endereco set Estado= @Estado  WHERE cpf=@CPF;";
                            Console.Write("Informe o novo Estado: ");
                            string EstadoNovo = Console.ReadLine();
                            cmdUpdateEST.Parameters.AddWithValue("@Estado", EstadoNovo);
                            cmdUpdateEST.Parameters.AddWithValue("@CPF", cpf);
                            cmdUpdateEST.Connection = conexaosql;
                            cmdUpdateEST.ExecuteNonQuery();
                            conexaosql.Close();
                            break;


                    }

                    break;
                case 5:
                    SqlCommand cmdUpdateT = new SqlCommand();
                    cmdUpdateT.CommandText = "UPDATE Adotante set Telefone = @Telefone WHERE cpf=@CPF;";
                    Console.Write("Informe o novo Telefone: ");
                    string t = Console.ReadLine();
                    cmdUpdateT.Parameters.AddWithValue("@Telefone", t);
                    cmdUpdateT.Parameters.AddWithValue("@CPF", cpf);
                    cmdUpdateT.Connection = conexaosql;
                    cmdUpdateT.ExecuteNonQuery();
                    conexaosql.Close();
                    break;

            }
            Console.WriteLine("Atualização finalizada!");
            Console.ReadKey();

        } // atualizo determinado campo,exceto o CPF(chave primária)
        public void DeletarAdotante()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            Console.Write("Informe o CPF que deseja excluir: ");
            string cpf = Console.ReadLine();
            //antes de excluir o adotante tenho que excluir os demais campos que contém ligação(chaves estrangeiras)
            SqlCommand cmdDELETEend = new SqlCommand();
            cmdDELETEend.CommandText = "DELETE FROM Endereco WHERE cpf=@CPF;";
            cmdDELETEend.Parameters.AddWithValue("@CPF", cpf);
            cmdDELETEend.Connection = conexaosql;


            SqlCommand cmdDELETEadocao = new SqlCommand();
            cmdDELETEadocao.CommandText = "DELETE FROM Adocao WHERE cpf=@CPF;";
            cmdDELETEadocao.Parameters.AddWithValue("@CPF", cpf);
            cmdDELETEadocao.Connection = conexaosql;

            SqlCommand cmdDELETEadotado = new SqlCommand();
            cmdDELETEadotado.CommandText = "DELETE FROM Adotante WHERE cpf=@CPF;";
            cmdDELETEadotado.Parameters.AddWithValue("@CPF", cpf);
            cmdDELETEadotado.Connection = conexaosql;

            cmdDELETEend.ExecuteNonQuery();
            cmdDELETEadocao.ExecuteNonQuery();
            cmdDELETEadotado.ExecuteNonQuery();
            conexaosql.Close();
            Console.WriteLine("Exclusão Finalizada!");
            Console.ReadKey();
        } // excluo 1 adotante
        #endregion

        #region Adotado
        public void InserirAdotado(Adotado adotado)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            string sql = $"INSERT INTO Adotado(Familia,Raca,Sexo,Nome) VALUES('{adotado.Familia}', " + $"'{adotado.Raca}','{adotado.Sexo}','{adotado.Nome}');";
            SqlCommand cmdINSERTadotado = new SqlCommand(sql, conexaosql);
            cmdINSERTadotado.ExecuteNonQuery();
            conexaosql.Close();
            Console.WriteLine("Adotado inserido com sucesso!");
            Console.ReadKey();
        } //adiciono 1 adotado
        public void VisualizarAdotados(Adotado adotado)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            cmdSELECTadotante.CommandText = "SELECT CHIP,Familia,Raca,Sexo,Nome FROM Adotado";
            cmdSELECTadotante.Connection = conexaosql;
            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())//permite o acesso ao banco de dados
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetInt32(0) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(1) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(2) + "\t");
                    Console.Write("{0}\t", sqlReader.GetString(3) + "\t");
                    Console.WriteLine("{0}\t", sqlReader.GetString(4) + "\t");
                }
            }
            Console.WriteLine("\nImpressão Finalizada!");
            Console.ReadKey();
        } // seleciono todos os adotados
        public Adotado BuscarAdotado(Adotado adotado)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            Console.Write("Informe o CHIP que deseja buscar: ");
            string chip = Console.ReadLine();
            cmdSELECTadotante.CommandText = "SELECT CHIP,Familia,Raca,Sexo,Nome FROM Adotado WHERE chip=@CHIP";
            cmdSELECTadotante.Parameters.AddWithValue("CHIP", chip);
            cmdSELECTadotante.Connection = conexaosql;
            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetInt32(0));
                    Console.Write("{0}\t", sqlReader.GetString(1));
                    Console.Write("{0}\t", sqlReader.GetString(2));
                    Console.Write("{0}\t", sqlReader.GetString(3));
                    Console.WriteLine("{0}\t", sqlReader.GetString(4));
                }
            }
            Console.WriteLine("\nBusca Finalizada!");
            Console.ReadKey();
            conexaosql.Close();
            return adotado;
        } // seleciono 1 adotado específico
        public void AtualizarCampoAdotado()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            Console.Write("CHIP: ");
            string chip = Console.ReadLine();
            Console.Write("Informe o campo que deseja editar: 0-Cancelar Edição  1-Familia  2-Raça  3-Sexo  4-Nome ");
            int campo = int.Parse(Console.ReadLine());
            switch (campo)
            {
                case 0:
                    return;
                case 1:
                    SqlCommand cmdUpdateN = new SqlCommand();
                    cmdUpdateN.CommandText = "UPDATE Adotado set Familia = @Familia  WHERE chip=@CHIP;";
                    Console.Write("Informe a nova Família: ");
                    string f = Console.ReadLine();
                    cmdUpdateN.Parameters.AddWithValue("@Familia", f);
                    cmdUpdateN.Parameters.AddWithValue("@CHIP", chip);
                    cmdUpdateN.Connection = conexaosql;
                    cmdUpdateN.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 2:
                    SqlCommand cmdUpdateS = new SqlCommand();
                    cmdUpdateS.CommandText = "UPDATE Adotado set Raca = @raca  WHERE chip=@CHIP;";
                    Console.Write("Informe a nova Raça: ");
                    string r = Console.ReadLine();
                    cmdUpdateS.Parameters.AddWithValue("@Raca", r);
                    cmdUpdateS.Parameters.AddWithValue("@CHIP", chip);
                    cmdUpdateS.Connection = conexaosql;
                    cmdUpdateS.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 3:
                    SqlCommand cmdUpdateSPet = new SqlCommand();
                    cmdUpdateSPet.CommandText = "UPDATE Adotado set Sexo = @sexo  WHERE chip=@CHIP;";
                    Console.Write("Informe o novo Sexo: ");
                    char sPet = char.Parse(Console.ReadLine());
                    cmdUpdateSPet.Parameters.AddWithValue("@Sexo", sPet);
                    cmdUpdateSPet.Parameters.AddWithValue("@CHIP", chip);
                    cmdUpdateSPet.Connection = conexaosql;
                    cmdUpdateSPet.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
                case 4:
                    SqlCommand cmdUpdateNPet = new SqlCommand();
                    cmdUpdateNPet.CommandText = "UPDATE Adotado set Nome = @Nome  WHERE chip=@CHIP;";
                    Console.Write("Informe o novo Nome: ");
                    string nPet = Console.ReadLine();
                    cmdUpdateNPet.Parameters.AddWithValue("@Nome", nPet);
                    cmdUpdateNPet.Parameters.AddWithValue("@CHIP", chip);
                    cmdUpdateNPet.Connection = conexaosql;
                    cmdUpdateNPet.ExecuteNonQuery();
                    conexaosql.Close();
                    break;
            }
            Console.WriteLine("\nAtualização realizada com sucesso!");
            Console.ReadKey();
        }  // atualizo determinado campo, exceto CHIP(chave primária)
        public void DeletarAdotado()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            Console.Write("Informe o CHIP que deseja excluir: ");
            int chip = int.Parse(Console.ReadLine());

            //Primeiro deleto a adoção (que tem chave primária dependente de adotado)
            SqlCommand cmdDELETEadocao = new SqlCommand();
            cmdDELETEadocao.CommandText = "DELETE FROM Adocao WHERE chip=@CHIP;";
            cmdDELETEadocao.Parameters.AddWithValue("@CHIP", chip);
            cmdDELETEadocao.Connection = conexaosql;

            //Depois deleto o adotado
            SqlCommand cmdDELETEP = new SqlCommand();
            cmdDELETEP.CommandText = "DELETE FROM Adotados WHERE chip=@CHIP;";
            cmdDELETEP.Parameters.AddWithValue("@CHIP", chip);
            cmdDELETEP.Connection = conexaosql;

            cmdDELETEadocao.ExecuteNonQuery();
            cmdDELETEP.ExecuteNonQuery();
            conexaosql.Close();
            Console.WriteLine("\nAdotado excluído com sucesso");
            Console.ReadKey();
        } // excluo 1 adotado
        #endregion

        #region Adoção
        public void InserirAdocao(Adocao adocao)
        {

            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            string sql = $"INSERT INTO Adocao(CPF,CHIP,DataAdocao) VALUES('{adocao.CPF}', " + $"'{adocao.CHIP}','{adocao.DataAdocao}');";
            SqlCommand cmdINSERTadocao = new SqlCommand(sql, conexaosql);

            cmdINSERTadocao.ExecuteNonQuery();
            conexaosql.Close();
            Console.WriteLine("\nAdoção cadastrada com sucesso!");
            Console.ReadKey();
        } //INSERT 
        public void VisualizarAdocao()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());

            conexaosql.Open();

            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Adotante.CPF, Adotante.Nome, Adotado.CHIP, Adotado.Nome, DataAdocao FROM Adocao inner join Adotante  on Adotante.CPF = Adocao.CPF inner join Adotado  on Adotado.CHIP = Adocao.CHIP;";
            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.Write("{0}\t", reader.GetString(0) + "\t");
                    Console.Write("{0}\t", reader.GetString(1) + "\t");
                    Console.Write("{0}\t", reader.GetInt32(2) + "\t");
                    Console.Write("{0}\t", reader.GetString(3) + "\t");
                    Console.WriteLine("{0}\t", reader.GetDateTime(4) + "\t");
                }
            }
            conexaosql.Close();
            Console.WriteLine("\nImpressão Finalizada!");
            Console.ReadKey();
        } //SELECT 
     
        #endregion

    }
}
