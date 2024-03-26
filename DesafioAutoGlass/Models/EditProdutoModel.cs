namespace API.Models
{
    public class EditProdutoModel
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public bool status { get; set; }
        public DateTime dataFabricacao { get; set; }
        public DateTime dataValidade { get; set; }
        public int codigoFornecedor { get; set; }
        public string descricaoFornecedor { get; set; }
        public string cnpjFornecedor { get; set; }
    }
}
