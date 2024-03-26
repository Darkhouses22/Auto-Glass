namespace API.Models
{
    public class ProdutoModel
    {
        public string? descricao { get; set; }
        public bool? status { get; set; }
        public DateTime? dataFabricacao { get; set; }
        public DateTime? dataValidade { get; set; }
        public int? codigoFornecedor { get; set; }
        public string? descricaoFornecedor { get; set; }
        public string? cnpjFornecedor { get; set; }
    }
}
