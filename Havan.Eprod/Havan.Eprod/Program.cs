using Havan.Eprod.Aplicacao;
using System;
using System.Text;

namespace Havan.Eprod
{
    class Program
    {
        private static CategoriaAplicacao _categoriaAplicacao;

        static void Main(string[] args)
        {
            _categoriaAplicacao = new CategoriaAplicacao();

            MontarMenu();

            Console.ReadKey();
        }

        static void MontaTitulo(string titulo)
        {
            var tamanho = 30;
            var t1 = tamanho - titulo.Length;
            var t2 = t1 / 2;
            var nmString = new StringBuilder();
            nmString.AppendLine("".PadLeft(tamanho, '='));
            nmString.Append("".PadLeft(t2, ' '));
            nmString.Append(titulo);
            nmString.AppendLine("".PadLeft(t2, ' '));
            nmString.AppendLine("".PadLeft(tamanho, '='));
            Console.WriteLine(nmString.ToString());
        }

        static void MontarMenu()
        {
            MontaTitulo("Menu");
            
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1 - Cadastrar Categoria");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine();
            Console.Write("Informe a opção escolhida: ");
            byte opcao = Convert.ToByte(Console.ReadLine());

            MontarSubmenu(opcao);
        }

        static void MontarSubmenu(byte item)
        {
            MontaTitulo("Submenu");
            
            switch (item)
            {
                case 1:
                    Console.WriteLine("1 - Cadastrar Categoria");
                    Console.WriteLine("2 - Lista Categoria");
                    Console.WriteLine("3 - Editar Categoria");
                    Console.WriteLine("4 - Excluir Categoria");
                    break;
                case 2:
                    Console.WriteLine("1 - Cadastrar Produto");
                    Console.WriteLine("2 - Lista Produto");
                    Console.WriteLine("3 - Editar Produto");
                    Console.WriteLine("4 - Excluir Produto");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    MontarMenu();
                    break;
            }


            Console.Write("Informe a opção escolhida: ");
            byte opcao = Convert.ToByte(Console.ReadLine());
            SelecionarFuncao(item, opcao);

        }

        static void SelecionarFuncao(byte cadastro, byte funcao)
        {
            switch(cadastro)
            {
                case 1:
                    switch(funcao)
                    {
                        case 1:
                            CadastrarCategoria();
                            break;
                        case 2:
                            ListarCategorias();
                            break;
                        case 3:
                            EditarCategoria();
                            break;
                        case 4:
                            ExcluirCategoria();
                            break;
                        default:
                            Console.WriteLine("Opção informada inválida");
                            SelecionarFuncao(cadastro, funcao);
                            break;
                    }
                    break;
                case 2: 
                    //switch(funcao)
                    //{
                    //    case 1:
                    //        CadastrarProduto();
                    //        break;
                    //    case 2:
                    //        ListarProduto();
                    //        break;
                    //    case 3:
                    //        EditarProduto();
                    //        break;
                    //    case 4:
                    //        ExcluirProduto();
                    //        break;
                    //    default:
                    //        Console.WriteLine("Opção informada inválida");
                    //        SelecionarFuncao(cadastro, funcao);
                    //        break;
                    //}
                    break;
                default:
                    Console.WriteLine("Opção informada inválida");
                    break;
            }
        }

        static void CadastrarCategoria()
        {
            Console.Write("Digite o nome da Categoria: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a Situacao(0 - Ativo, 1-Ativo): ");
            byte situacao = Convert.ToByte(Console.ReadLine());

            _categoriaAplicacao.AdicionarCategoria(nome, situacao);
            MontarMenu();
        }

        static void EditarCategoria()
        {
            Console.Write("Digite o Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o nome da Categoria: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a Situacao(0 - Ativo, 1-Ativo): ");
            byte situacao = Convert.ToByte(Console.ReadLine());

            _categoriaAplicacao.AtualizarCategoria(id, nome, situacao);
            MontarMenu();
        }

        static void ListarCategorias()
        {
            _categoriaAplicacao.ObterLista();
            MontarMenu();
        }

        static void ExcluirCategoria()
        {
            Console.Write("Digite o Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _categoriaAplicacao.RemoverCategoria(id);
            MontarMenu();
        }
    }
}
