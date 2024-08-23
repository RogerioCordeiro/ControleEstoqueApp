using System.ComponentModel.Design;

namespace ControleEstoqueApp
{
    public class Program
    {
        
        // Inicio do sistema!
        static void Main(string[] args)
        {
            // Id de cadastro dos produtos, para melhor controle.
            int idCadastro = 1;
            int qtdProdutos = 0;
            bool inicio = true;

            Produto[] produtos = new Produto[1];
            
            Funcoes.EscreverNaTela(@"
                Seja Bem Vindo ao 
                Tô no Estoque
                Se a gente não souber onde tá, ninguém sabe!
                ");

            while (inicio)
            {
                Produto produto = new Produto();

                int opcao = Funcoes.OpcoesMenu();

                switch (opcao)
                {
                    case 0:

                        inicio = false;
                        break;

                    case 1:

                        produto = Funcoes.CadastrarProduto(idCadastro);

                        if (qtdProdutos == produtos.Length)
                        {
                            Produto[] novosProdutos = new Produto[produtos.Length + 1];
                            Array.Copy(produtos, novosProdutos, produtos.Length);
                            produtos = novosProdutos;
                        }

                        produtos[qtdProdutos] = produto;
                        qtdProdutos++;

                        idCadastro++;
                        break;

                    case 2:

                        Funcoes.ExibirProdutos(produtos);
                        break;

                    case 3:

                        Funcoes.EscreverNaTela("Digite a posição do produto que deseja excluir.");
                        int idExcluir = Convert.ToInt32(Console.ReadLine());
                        qtdProdutos = produtos.Length - 1;
                        produtos = Funcoes.ExcluirProduto(produtos, idExcluir);
                        
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:
                        Funcoes.EscreverNaTela("Opção Escolhida invalida digite novamente!");
                        break;

                }
            }

        }
    }
}
