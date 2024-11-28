using AS.Data;
using Microsoft.EntityFrameworkCore;

public class PedidosRepository : IPedidosRepository
{
    private readonly AppDbContext _context;
    public PedidosRepository(AppDbContext context)
    {
        _context = context;
    }
    //async == metodo assincrono
    public async Task AdicionarPedido(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<Pedido> AtualizarPedido(int id, Pedido pedidoAtualizado)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
         if (pedido == null)
         return pedido;

        pedido.Id = pedidoAtualizado.Id;
        pedido.Data = pedidoAtualizado.Data;
        pedido.ValorTotal = pedidoAtualizado.ValorTotal;
        pedido.Status = pedidoAtualizado.Status;
        pedido.Descricao = pedidoAtualizado.Descricao;

        await _context.SaveChangesAsync();
        return pedido;
       
    }

    public async Task<Pedido> DeletarPedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
         if (pedido == null)
            return pedido;
        
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> GetPedido(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task<List<Pedido>> GetTodosPedidos()
    {
        return await _context.Pedidos.ToListAsync();
        
    }
}