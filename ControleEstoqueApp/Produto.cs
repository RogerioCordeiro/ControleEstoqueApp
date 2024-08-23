namespace ControleEstoqueApp
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nome { get; set; }
        public double precoVenda { get; set; }
        public double precoCompra { get; set; }
        public double quantidadeEstoque { get; set; }
        public string fornecedor { get; set; }
        public DateTime dataValidade { get; set; }
    }
}
