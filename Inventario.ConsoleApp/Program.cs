using System;
using System.Collections.Generic;

namespace Inventario.ConsoleApp
{
    class Program
    {
        static int id = 1;
        static List<Produto> produtos = new List<Produto>();
        static List<Chamados> chamados = new List<Chamados>();

        static void Main(string[] args)
        {
            var cust1 = new Produto()
            {
                Id = id++,
                nomeProduto = "Teclado",
                precoProduto = "200",
                dataProduto = "20/10/2020",
                fabriProduto = "Razer"

            };
            produtos.Add(cust1);

            produtos.Add(new Produto()
            {
                Id = id++,
                nomeProduto = "Mouse",
                precoProduto = "100",
                dataProduto = "10/01/2020",
                fabriProduto = "Multilaser"
            });

            chamados.Add(new Chamados()
            {
                Id = id++,
                tituloChamado = "Manutenção mouse",
                descriChamado = "Arrumar sensor do mouse",
                dataChamado = "16/04/2020",
                equipChamado = "Teclado"
            });

            string[] menuItems = {
                "Mostre todos os produtos",
                "Adicionar um produto",
                "Deletar um produto",
                "Editar um produto",
                "Listar os chamados",
                "Abrir um chamado",
                "Editar um chamado",
                "Excluir os chamados",
                "Sair"
            };

            var selection = MostrarMenu(menuItems);

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        ListarProdutos();
                        break;
                    case 2:
                        AddProduto();
                        break;
                    case 3:
                        ExcluirProduto();
                        break;
                    case 4:
                        EditarProduto();
                        break;
                    case 5:
                        ListarChamado();
                        break;
                    case 6:
                        AbrirChamado();
                        break;
                    case 7:
                        EditarChamado();
                        break;
                    case 8:
                        ExcluirChamado();
                        break;
                    default:
                        break;
                }
                selection = MostrarMenu(menuItems);
            }
            Console.WriteLine("Até mais :)");

            Console.ReadLine();
        }
        //Editar um produto, primeiro pede o ID, após isso as informaçoes.
        private static void EditarProduto()
        {
            var produto = EncontrarProdutoPorId();
            Console.WriteLine("Nome do equipamento: ");
            produto.nomeProduto = Console.ReadLine();
            Console.WriteLine("Preço do equipamento: ");
            produto.precoProduto = Console.ReadLine();
            Console.WriteLine("Data de fabricação (DD/MM/AAAA): ");
            produto.dataProduto = Console.ReadLine();

        }
        //Método para encontrar um produto pelo iD
        private static Produto EncontrarProdutoPorId()
        {
            Console.WriteLine("Insira o ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Por favor, digite um número válido");
            }

            foreach (var produto in produtos)
            {
                if (produto.Id == id)
                {
                    return produto;
                }
            }
            return null;
        }
        //Excluir um produto
        private static void ExcluirProduto()
        {

            var customerFound = EncontrarProdutoPorId();
            if (customerFound != null)
            {
                produtos.Remove(customerFound);
            }
        }
        //Adicionar um produto
        private static void AddProduto()
        {
            Console.WriteLine("Nome do Produto: ");
            var nomeProduto = Console.ReadLine();

            Console.WriteLine("Preço do Produto: ");
            var precoProduto = Console.ReadLine();

            Console.WriteLine("Data de Fabricação (DD/MM/AAAA): ");
            var dataProduto = Console.ReadLine();

            Console.WriteLine("Fabricante do produto: ");
            var fabriProduto = Console.ReadLine();

            produtos.Add(new Produto()
            {
                Id = id++,
                nomeProduto = nomeProduto,
                precoProduto = precoProduto,
                dataProduto = dataProduto,
                fabriProduto = fabriProduto,
            });
        }
        

        //Listar os produtos
        private static void ListarProdutos()
        {
            Console.WriteLine("\nLista de Equipamentos");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Id: {produto.Id} Nome do Produto: {produto.nomeProduto} " +
                                $"{produto.precoProduto} " +
                                $"Data de Fabricação: {produto.dataProduto}");
            }
            Console.WriteLine("\n");

        }
        //Mostrar o menu inicial
        private static int MostrarMenu(string[] menuItems)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Inventário Academia do Programador\n"); 
            
            for (int i = 0; i < menuItems.Length; i++)
            {
                
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 9)
            {
                Console.WriteLine("Por favor selecione um número de 1-9");
            }

            return selection;
        }

        private static Chamados EncontrarProdutoPorId1()
        {
            Console.WriteLine("Insira o ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Por favor, digite um número válido");
            }

            foreach (var chamado in chamados)
            {
                if (chamado.Id == id)
                {
                    return chamado;
                }
            }
            return null;
        }

        //Listar Chamados
        private static void ListarChamado()
        {
            Console.WriteLine("\nLista de Chamados");
            foreach (var chamado in chamados)
            {
                Console.WriteLine($"Id: {chamado.Id} Título do Chamado: {chamado.tituloChamado} " +
                                $" Descrição do Chamado: {chamado.descriChamado} " +
                                $"Data do Chamado: {chamado.dataChamado} " +
                                $"{chamado.equipChamado} ");
            }
            Console.WriteLine("\n");

        }

        //Abrir chamado
        private static void AbrirChamado()
        {
            Console.WriteLine("Título do chamado: ");
            var tituloChamado = Console.ReadLine();

            Console.WriteLine("Descrição do chamado: ");
            var descriChamado = Console.ReadLine();

            Console.WriteLine("Abertura do chamado: (DD/MM/AAAA): ");
            var dataChamado = Console.ReadLine();

            Console.WriteLine("Equipamento: ");
            var equipChamado = Console.ReadLine();

            chamados.Add(new Chamados()
            {
                Id = id++,
                tituloChamado = tituloChamado,
                descriChamado = descriChamado,
                dataChamado = dataChamado,
                equipChamado = equipChamado,
            });
        }

        private static void EditarChamado()
        {
            var chamado = EncontrarProdutoPorId1();
            Console.WriteLine("Nome do equipamento: ");
            chamado.tituloChamado = Console.ReadLine();
            Console.WriteLine("Preço do equipamento: ");
            chamado.descriChamado = Console.ReadLine();
            Console.WriteLine("Data do chamado (DD/MM/AAAA): ");
            chamado.dataChamado = Console.ReadLine();
            Console.WriteLine("Equipamento: ");
            var equipChamado = Console.ReadLine();

        }

        private static void ExcluirChamado()
        {

            var encontrarChamado = EncontrarProdutoPorId1();
            if (encontrarChamado != null)
            {
                chamados.Remove(encontrarChamado);
            }
        }

    }
    //Classe declarando os atributos que estão sendo utilizados
    internal class Produto
    {
        public Produto()
        {
        }
 
        public string nomeProduto { get; set; }
        public string precoProduto { get; set; }
        public int Id { get; set; }
        public string dataProduto { get; set; }
        public string fabriProduto { get; set; }
    }

    internal class Chamados
    {
        public Chamados()
        {
        }

        public string tituloChamado { get; set; }
        public string descriChamado { get; set; }
        public int Id { get; set; }
        public string dataChamado { get; set; }
        public string equipChamado { get; set; }
    }

}