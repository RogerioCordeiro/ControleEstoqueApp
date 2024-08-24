namespace ControleEstoqueApp
{
    public class Funcoes
    {

        // Função para reduzir a escrita de Console.WriteLine.
        public static void EscreverNaTela(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        // Função que exibir o menu de opções na tela!
        public static int OpcoesMenu()
        {

            EscreverNaTela(@"
Escolha uma opção:
[ 1 ] Cadastrar Produto
[ 2 ] Todos os Produtos
[ 3 ] Remover Produto
[ 4 ] Entrada de Estoque
[ 5 ] Saída de Estoque
[ 0 ] Sair
");

            EscreverNaTela("Escolha uma opção:");
            
            int escolha = Convert.ToInt32(Console.ReadLine());
            return escolha;
        }

        // Função que realiza o cadastro do produto novo
        public static Produto[] CadastrarProduto(Produto[] produtos, int id)
        {
            Produto produto = new Produto();

            produto.idProduto = id;

            EscreverNaTela("Digite nome do produto:");
            produto.nome = Console.ReadLine();
            
            EscreverNaTela("Digite o preço de venda:" );
            produto.precoVenda = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite o preço de compra:");
            produto.precoCompra = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite a quantidade de estoque inicial.");
            produto.quantidadeEstoque = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite o nome do fornecedor:");
            produto.fornecedor = Console.ReadLine();
            
            EscreverNaTela("Digite a data de válidade (formato dd/mm/aaaa 01/01/2024)");
            produto.dataValidade = DateTime.Parse(Console.ReadLine());

            // Verificar se o array está vazio para adiconar um novo produto
            if (produtos.Length == 0 || produtos[produtos.Length - 1] != null)
            {
                // Redimensionar o array para acomodar o novo produto e manter os anteriores
                Produto[] novosProdutos = new Produto[produtos.Length + 1];
                Array.Copy(produtos, novosProdutos, produtos.Length);
                produtos = novosProdutos;
            }

            // Adicionar o produto ao array já redimencionado corretamente.
            produtos[produtos.Length - 1] = produto;

            EscreverNaTela($"\n{produto.nome} cadastrado com sucesso!");

            // Pausa de 3 segundos no codigo para melhor visualizar as respostas!
            Thread.Sleep(2000);
            return produtos;
        }

        // Exibi todos os produtos na tela, recebendo como parametro um ARRAY de produtos
        public static void ExibirProdutos(Produto[] produtos)
        {
            if (produtos.Length > 0)
            {
                EscreverNaTela("--------------------------------------------------------------------------------------");
                EscreverNaTela("Id".PadRight(8) + "| Nome".PadRight(38) + "| Preço venda".PadRight(15) + "| Estoque\n");
                for (int i = 0; i < produtos.Length; i++)
                {
                    EscreverNaTela($"{produtos[i].idProduto}".PadRight(10) + $"{produtos[i].nome}".PadRight(38) + $"R$ {produtos[i].precoVenda}".PadRight(15) + $"{produtos[i].quantidadeEstoque} no estoque.");
                }
            }
            else
            {
                EscreverNaTela("--------------------------------------------------------------------------------------\n");
                EscreverNaTela("Não possui nenhum produto cadastrado, digite 1 para iniciar um cadastro.\n");
                EscreverNaTela("--------------------------------------------------------------------------------------\n");
            }
            // Pausa de 3 segundos no codigo para melhor visualizar as respostas!
            Thread.Sleep(2000);
        }

        // Excluir um produto cadastrado, necessario informar um Array de produtos e o ID do produto que deseja excluir.
        public static Produto[] ExcluirProduto(Produto[] produtos)
        {
            Funcoes.EscreverNaTela(@"Digite o ID do produto que deseja EXCLUIR. (Atenção operação NÃO pode ser desfeita.)
Digite 0 para abortar!");

            int idExcluir = Convert.ToInt32(Console.ReadLine());

            Produto[] tempProdutos = new Produto[produtos.Length - 1];
            int indice = 0;
            if (idExcluir == 0)
            {
                EscreverNaTela($"Operação cancelada.");
                Thread.Sleep(2000);
                return produtos;
            }
            foreach (var item in produtos)
            {
                if (item.idProduto != idExcluir)
                {
                    tempProdutos[indice] = item;
                    indice++;
                }
                else
                {
                    EscreverNaTela($"{item.nome} excluido com sucesso.");
                }
            }
            // Pausa de 3 segundos no codigo para melhor visualizar as respostas!
            Thread.Sleep(2000);
            return tempProdutos;
        }

        // Função para lançar entrada estoque, necessario informar um id do produto e a quantidade de entrada do estoque que será lançado. 
        // Valor será somado ao estoque atual do produto
        public static Produto[] EntradaEstoque(Produto[] produtos)
        {
            return GestaoEstoque(produtos, "adicionar");
        }

        // Função para lançar saida de estoque, necessario informar um id do produto e a quantidade de saida de estoque que será lançado
        public static Produto[] SaidaEstoque(Produto[] produtos)
        {
           return GestaoEstoque(produtos, "saida");
        }

        private static Produto[] GestaoEstoque(Produto[] produtos, string opercao)
        {
            // Verificar se o array está vazio casso esteja exibi a mensagem de que não possui produtos cadastrados
            if (produtos.Length == 0 || produtos[produtos.Length - 1] != null)
            {
                Funcoes.EscreverNaTela($"Digite o ID do produto para {opercao.ToUpper()} estoque.");

                int idProduto = Convert.ToInt32(Console.ReadLine());
                
                int indice = ProdutoExiste(idProduto, produtos);
                
                if (indice >= 0)
                {
                    string nome = produtos[indice].nome;
                    double estAnt = produtos[indice].quantidadeEstoque;

                    string lancamento = (opercao.ToLower() == "adicionar") ? "ADICIONAR ao" : "registrar a SAÍDA de";
                    Funcoes.EscreverNaTela($"Digite a QUANTIDADE para {lancamento} estoque de {nome}.");

                    lancamento = (opercao.ToLower() == "adicionar") ? "SOMADA ao" : "SUBTRAÍDA do";
                    Funcoes.EscreverNaTela($"Atenção será {lancamento} estoque atual de {estAnt}.");

                    double qtdEstoque = Convert.ToDouble(Console.ReadLine());

                    if (opercao.ToLower() == "adicionar")
                    {
                        EscreverNaTela("Entrada de estoque lançado com sucesso!\n");
                        produtos[indice].quantidadeEstoque += qtdEstoque;
                    }
                    else if (opercao.ToLower() == "saida")
                    {
                        EscreverNaTela("Saída de estoque lançada com sucesso!\n");
                        produtos[indice].quantidadeEstoque -= qtdEstoque;
                    }
                }
                else
                {
                    EscreverNaTela("\nO ID digitado não foi localizado. Verifique o ID digitado.");
                }
            }
            else
            {
                EscreverNaTela("\nNão existe produtos cadastrados para \nlançar entrada de estoque seleciona a opção 1 para cadastrar um produto.");
            }
            // Pausa de 3 segundos no codigo para melhor visualizar as respostas!
            Thread.Sleep(2000);
            return produtos;
        }

        // Função que verifica se um produto está cadastrado no Array de produtos, necessario um parametro que é o Id do produto e 
        private static int ProdutoExiste(int idProduto, Produto[] produtos)
        {
            int indice = -1;
            for (int i = 0; i < produtos.Length; i++)
            {
                if (produtos[i].idProduto == idProduto)
                {
                    indice = i;
                    break;
                }
            }
            return indice; 
        }
    }
}
