//classe pedidos
public class Pedido
{
    //atributos da classe pedido
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public string? Status { get; set; }
    public string? Descricao { get; set; }
}