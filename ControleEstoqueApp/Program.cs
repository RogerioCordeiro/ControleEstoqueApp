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

            Produto[] produtos = new Produto[qtdProdutos];
            
            Funcoes.EscreverNaTela(@"Seja Bem Vindo ao Sistema!
Tô no Estoque: Se a gente não souber onde tá, ninguém sabe!
Sistema ideal para sua Mercearia!");

            while (inicio)
            {
                int opcao = Funcoes.OpcoesMenu();

                switch (opcao)
                {
                    case 0:
                        inicio = false;
                        break;

                    case 1:
                        produtos = Funcoes.CadastrarProduto(produtos, idCadastro);
                        idCadastro ++;
                        break;

                    case 2:
                        Funcoes.ExibirProdutos(produtos);
                        break;

                    case 3:
                        produtos = Funcoes.ExcluirProduto(produtos);
                        break;

                    case 4:
                        Funcoes.EntradaEstoque(produtos);
                        break;

                    case 5:
                        Funcoes.SaidaEstoque(produtos);
                        break;

                    default:
                        Funcoes.EscreverNaTela("Opção Escolhida invalida digite novamente!");
                        break;

                }
            }

        }
    }
}
