public interface IPedidosRepository
{
    // Método assíncrono para listar todos os pedidos.
    public Task<List<Pedido>> GetTodosPedidos();
    // Método assíncrono para listar pedido pelo ID.
    public Task<Pedido> GetPedido(int id);
    // Método assíncrono para adicionar um novo pedido.
    public Task AdicionarPedido(Pedido pedido);
    // Método assíncrono para editar as informações de um pedido existente.
    public Task<Pedido> AtualizarPedido(int id, Pedido pedidoAtualizado);
    // Método assíncrono para deletar um pedido pelo ID.
    public Task<Pedido> DeletarPedido(int id);
}