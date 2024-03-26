using System;

public class Produto
{
	public Produto()
	{
	}

	public int codigo { get; set; }
	public string descricao { get; set; }
	public string status { get; set; }
	public Datetime dataFabricacao { get; set; }
	public Datetime dataValidade { get; set; }
	public int codigoFornecedor { get; set; }
	public string descricaoFornecedor { get; set; }
	public string cnpjFornecedor { get; set; }
}
