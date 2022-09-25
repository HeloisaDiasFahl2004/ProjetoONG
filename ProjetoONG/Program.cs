using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Program
    {
        Adotante adotante = new Adotante();
        static void Menu()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t<<< MENU >>>");
                Console.WriteLine("\t 0-Sair do Menu");
                Console.WriteLine("\t 1-Menu Adotante");
                Console.WriteLine("\t 2-Menu Adotado");
                Console.Write("\t Escolha uma opção: ");
                opc = int.Parse(Console.ReadLine());


                switch (opc)
                {
                    case 0:
                        Console.Write("Saindo . ");
                        Thread.Sleep(200);
                        Console.Write(" .");
                        Thread.Sleep(200);
                        Console.Write(" .");
                        Thread.Sleep(200);
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Write("Encaminhando para o menu adotante .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        MenuAdotante();
                        break;
                    case 2:
                        Console.Write("Encaminhando para o menu adotado .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        MenuAdotado();
                        break;
                    default:
                        Console.Write("Opção Inválida!");
                        break;

                }
            } while (opc != 0);
        } //3 opções -> sair/menu adotante/ menu adotado
        static void InserirAdotante(Adotante adotante)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            string sql = $"INSERT INTO Adotante(Nome, CPF, Sexo, DataNascimento, EnderecoCompleto, Telefone) VALUES('{adotante.Nome}' ," + $"'{adotante.CPF}' , '{adotante.Sexo}' , '{adotante.DataNascimento}' , '{adotante.Endereco}' , '{adotante.Telefone}');";
            SqlCommand cmdINSERTadotante = new SqlCommand(sql, conexaosql);
            cmdINSERTadotante.ExecuteNonQuery();
            conexaosql.Close();
        } // adiciono 1 adotante
        static void VisualizarAdotantes(Adotante adotante)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            cmdSELECTadotante.CommandText = "SELECT Nome,CPF,Sexo,DataNascimento,EnderecoCompleto,Telefone FROM Adotante";
            cmdSELECTadotante.Connection = conexaosql;
            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())//permite o acesso ao banco de dados
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetString(0));
                    Console.Write("{0}\t", sqlReader.GetString(1));
                    Console.Write("{0}\t", sqlReader.GetChar(2));
                    Console.Write("{0}\t", sqlReader.GetDateTime(3));
                    Console.WriteLine("{0}\t", sqlReader.GetString(4));
                    Console.WriteLine("{0}\t", sqlReader.GetString(5));
                }
            }
        } // seleciono todos os adotantes
        static void BuscarAdotante()
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            SqlCommand cmdSELECTadotante = new SqlCommand();
            Console.Write("Informe o CPF que deseja buscar: ");
            string cpf = Console.ReadLine();
            cmdSELECTadotante.CommandText = "SELECT Nome,CPF,Sexo,DataNascimento,EnderecoCompleto,Telefone FROM Adotante WHERE cpf=@CPF";
            cmdSELECTadotante.Connection = conexaosql;
            using (SqlDataReader sqlReader = cmdSELECTadotante.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Console.Write("{0}\t", sqlReader.GetString(0));
                    Console.Write("{0}\t", sqlReader.GetString(1));
                    Console.Write("{0}\t", sqlReader.GetChar(2));
                    Console.Write("{0}\t", sqlReader.GetDateTime(3));
                    Console.WriteLine("{0}\t", sqlReader.GetString(4));
                    Console.WriteLine("{0}\t", sqlReader.GetString(5));
                }
            }
            
        } // seleciono 1 adotante específico
        static void AtualizarCampoAdotante()
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
                    MenuAdotante();
                    break;
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
                            SqlCommand cmdUpdateB= new SqlCommand();
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
                            char EstadoNovo = char.Parse(Console.ReadLine());
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

        } // atualizo determinado campo,exceto o CPF(chave primária)
        static void InserirAdotado(Adotado adotado)
        {
            BD bd = new BD();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            conexaosql.Open();
            string sql = $"INSERT INTO Adotado(Familia,Raca,Sexo,Nome) VALUES('{adotado.Familia}', " + $"'{adotado.Raca}','{adotado.Sexo}','{adotado.Nome}');";
            SqlCommand cmdINSERTadotado = new SqlCommand(sql, conexaosql);
            cmdINSERTadotado.ExecuteNonQuery();
            conexaosql.Close();
        }
        static void MenuAdotante()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t<<< MENU ADOTANTE >>>");
                Console.WriteLine("\t 0-Retornar ao menu principal");
                Console.WriteLine("\t 1-Cadastrar Adotante");
                Console.WriteLine("\t 2-Editar Adotante");
                Console.WriteLine("\t 3-Deletar Adotante");
                Console.WriteLine("\t 4-Exibir Adotante");
                Console.Write("\t Escolha uma opção: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        Adotante adotante = new Adotante();//crio o objeto
                        adotante.CadastrarAdotante();//cadastro esse objeto
                        InserirAdotante(adotante);//insero esse objeto no banco de dados
                        break;

                    case 2:
                        AtualizarCampoAdotante();
                        break;

                    case 3:

                        break;

                    case 4:
                        adotante = new Adotante();
                        Console.WriteLine("Deseja: 1-Visualizar TODOS os adotantes 2- UM adotante em específico");
                        int resp = int.Parse(Console.ReadLine());

                        if (resp == 1) VisualizarAdotantes(adotante);

                        else if (resp == 2) BuscarAdotante();

                        else Console.WriteLine("Opção Inválida!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }
            } while (opc != 0);
        }
        static void MenuAdotado()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t<<< MENU ADOTADO >>>");
                Console.WriteLine("\t 0-Retornar ao menu principal");
                Console.WriteLine("\t 1-Cadastrar Adotado");
                Console.WriteLine("\t 2-Editar Adotado");
                Console.WriteLine("\t 3-Deletar Adotado");
                Console.WriteLine("\t 4-Exibir Adotado");
                Console.Write("\t Escolha uma opção: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        Adotado adotado = new Adotado();
                        adotado.CadastrarAdotado();
                        InserirAdotado(adotado);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opc != 0);
        }
        static void Main(string[] args)
        {
            Menu();
        }

    }
}

