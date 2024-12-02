using AS.Data;
using Microsoft.EntityFrameworkCore;

//classe que herda da interface IPedidosRepository
public class PedidosRepository : IPedidosRepository
{
    // Campo privado para acessar o contexto do banco de dados
    private readonly AppDbContext _context;

    // Construtor que recebe o AppDbContext via injeção de dependência
    public PedidosRepository(AppDbContext context)
    {
        _context = context;
    }
    //async == metodo assincrono
    // Método assíncrono para adicionar um novo pedido
    public async Task AdicionarPedido(Pedido pedido)
    {
        // Adiciona o pedido à tabela Pedidos
        await _context.Pedidos.AddAsync(pedido);
        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
    }

    // Método assíncrono para edita os dados de um pedido
    public async Task<Pedido> AtualizarPedido(int id, Pedido pedidoAtualizado)
    {
        // Busca o pedido pelo ID no banco
        var pedido = await _context.Pedidos.FindAsync(id);
         if (pedido == null)
         return pedido;
        
        // Atualiza os dados do pedido com os novos valores fornecidos
        pedido.Data = pedidoAtualizado.Data;
        pedido.ValorTotal = pedidoAtualizado.ValorTotal;
        pedido.Status = pedidoAtualizado.Status;
        pedido.Descricao = pedidoAtualizado.Descricao;

        //Salva e retorna o pedido atualizado
        await _context.SaveChangesAsync();
        return pedido;
       
    }

    // Método assíncrono para deletar um pedido pelo ID
    public async Task<Pedido> DeletarPedido(int id)
    {
        // Busca o pedido pelo ID no banco
        var pedido = await _context.Pedidos.FindAsync(id);
         if (pedido == null)
            return pedido;

         // Remove o pedido do banco de dados, salva e retorna que o pedido foi deletado
                _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    // Método assíncrono para buscar um pedido pelo ID
    public async Task<Pedido> GetPedido(int id)
    {
        // Retorna o pedido encontrado ou null se não existir
        return await _context.Pedidos.FindAsync(id);
    }

     // Método assíncrono para buscar todos os pedidos
    public async Task<List<Pedido>> GetTodosPedidos()
    {
        // Retorna uma lista de todos os pedidos
        return await _context.Pedidos.ToListAsync();
        
    }
}