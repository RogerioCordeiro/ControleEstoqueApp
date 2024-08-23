namespace ControleEstoqueApp
{
    public class Funcoes
    {

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

        // Função para reduzir a escrita de Console.WriteLine.
        public static void EscreverNaTela(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        // Função que realiza o cadastro do produto novo
        public static Produto CadastrarProduto(int id)
        {
            Produto produto = new Produto();

            produto.idProduto = id;

            EscreverNaTela("Digite nome do produto:");
            produto.nome = Console.ReadLine();
            
            EscreverNaTela("Digite o preço de venda:" );
            produto.precoVenda = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite o preço de compra:");
            produto.precoVenda = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite a quantidade de estoque inicial.");
            produto.quantidadeEstoque = Convert.ToDouble(Console.ReadLine());
            
            EscreverNaTela("Digite o nome do fornecedor:");
            produto.fornecedor = Console.ReadLine();
            
            EscreverNaTela("Digite a data de válidade (formato dd/mm/aaaa 01/01/2024)");
            produto.dataValidade = DateTime.Parse(Console.ReadLine());

            EscreverNaTela($"\n{produto.nome} cadastrado com sucesso!\n");

            return produto;
        }

        public static void ExibirProdutos(Produto[] produtos)
        {
            EscreverNaTela("Id |Nome               | Preço venda | Quantidade em estoque");
            for (int i = 0; i < produtos.Length; i++)
            {
                EscreverNaTela($"{produtos[i].idProduto}. {produtos[i].nome} ({produtos[i].precoVenda}) - {produtos[i].quantidadeEstoque} no estoque.");
            }
        }

        public static Produto[] ExcluirProduto(Produto[] produtos, int idProdutoRemovido)
        {
            Produto[] tempProdutos = new Produto[produtos.Length - 1];
            int indice = 0;
            foreach (var item in produtos)
            {
                if (item.idProduto != idProdutoRemovido)
                {
                    tempProdutos[indice] = item;
                    indice++;
                }
                else
                {
                    EscreverNaTela($"{item.nome} excluido com sucesso.");
                }
            }
            
            return tempProdutos;
        } 
    }
}
