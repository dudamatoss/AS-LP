using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
[ApiController]
[Route("[controller]")]

public class PedidosController : ControllerBase
{

private readonly IPedidosRepository _repository;

public PedidosController(IPedidosRepository repository)
{
    _repository = repository;
}

    [HttpGet]
    public async Task <ActionResult<List<Pedido>>> Get()
    {
        var pedidos = await _repository.GetTodosPedidos();
        return Ok(pedidos);
    }
    [HttpGet("{id}")]
    public async Task< ActionResult<Pedido>> Get(int id)
    {
       var pedido = await _repository.GetPedido(id);
        
        if (pedido == null)
            return NotFound();
        
        return Ok(pedido);

    }
    [HttpPost]
    public async Task <ActionResult> Post(Pedido pedido)
    {
        await _repository.AdicionarPedido(pedido);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task <ActionResult<Pedido>> Put(int id, Pedido pedidoAtualizado)
    {
       var pedido = await _repository.AtualizarPedido(id,pedidoAtualizado);
        if(pedido==null)
        return NotFound();

        
        return Ok(pedido);
    }
    [HttpDelete("{id}")]
    public async Task< ActionResult> Delete(int id)
    {
        var pedidoParaRemover = await _repository.DeletarPedido(id);
        if (pedidoParaRemover == null)
            return NotFound();
        
        
        return NoContent();




    }
}