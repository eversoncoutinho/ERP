namespace Domain
{
    public class Produto:Entity
    {
        public string? Nome { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public int Quantidade { get; set; }
        public string? Fornecedor { get; set; }
    }
}