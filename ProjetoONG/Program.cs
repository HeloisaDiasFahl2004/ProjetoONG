using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoONG
{
    internal class Program
    {
       static Adotante adotante = new Adotante();
       static Adotado adotado = new Adotado();
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
                Console.WriteLine("\t 3-Adoção");
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
                        Console.Write("Encaminhando para o menu adotante . ");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        MenuAdotante();
                        break;
                    case 2:
                        Console.Write("Encaminhando para o menu adotado . ");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        MenuAdotado();
                        break;
                    case 3:
                        Console.Write("Encaminhando para o menu adoção . ");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        Console.Write(" .");
                        Thread.Sleep(350);
                        MenuAdocao();
                        break;
                    default:
                        Console.Write("Opção Inválida!");
                        break;

                }
            } while (opc != 0);
        } //4 opções -> sair/menu adotante/ menu adotado/adoção
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
                        adotante.InserirAdotante(adotante);//insero esse objeto no banco de dados
                        break;

                    case 2:
                        adotante = new Adotante();
                        adotante.AtualizarCampoAdotante();
                        break;

                    case 3:

                        break;

                    case 4:
                        adotante = new Adotante();
                        Console.WriteLine("Deseja: 1-Visualizar TODOS os adotantes 2- UM adotante em específico");
                        int resp = int.Parse(Console.ReadLine());

                        if (resp == 1) adotante.VisualizarAdotantes(adotante);

                        else if (resp == 2) adotante.BuscarAdotante(adotante);

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
                        adotado.InserirAdotado(adotado);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opc != 0);
        }
        static void MenuAdocao()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t<<< MENU ADOÇÃO >>>");
                Console.WriteLine("\t 0-Retornar ao menu principal");
                Console.WriteLine("\t 1-Cadastrar Adoção");
                Console.WriteLine("\t 2-Exibir Adoção");
                Console.Write("\t Escolha uma opção: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        Adocao adocao = new Adocao();
                        adocao.CadastrarAdocao();
                        adocao.InserirAdocao(adocao);
                        break;
                    case 2:
                        adocao = new Adocao();
                        adocao.VisualizarAdocao(); //SELECT
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

