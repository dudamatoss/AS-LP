using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
[ApiController]
//definição da rota base
[Route("[controller]")]

//classa FornecedorController que herda de controllerBase
public class PedidosController : ControllerBase
{

//campo privado e imutável
private readonly IPedidosRepository _repository;

//metodo construtor -- parametro repository
public PedidosController(IPedidosRepository repository)
{
    _repository = repository;
}
    //metodo de listar pedido 
    //async porque ele realiza operações assíncronas
    //Após obter a lista, retorna um Ok (200)
    [HttpGet]
    public async Task <ActionResult<List<Pedido>>> Get()
    {
        var pedidos = await _repository.GetTodosPedidos();
        return Ok(pedidos);
    }
    //metodo listar por id
    //tem como parametro id
    //casa fornecedor não for encontrado, reotorna not found(404)
    [HttpGet("{id}")]
    public async Task< ActionResult<Pedido>> Get(int id)
    {
       var pedido = await _repository.GetPedido(id);
            if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }
    //metodo de criar
    //chama o metodo de criar fornecedor e retorna created 
    [HttpPost]
    public async Task <ActionResult> Post(Pedido pedido)
    {
        await _repository.AdicionarPedido(pedido);
        return Created();
    }
    //metodo de editar fornecedor
    //chama o metodo de atualezar fornecedor que me como parametro id  e fornecedorAtualizado
    //se fornecedor não for encontrado, retona not found (404)
    //caso contrario, retorna ok (200)
    [HttpPut("{id}")]
    public async Task <ActionResult<Pedido>> Put(int id, Pedido pedidoAtualizado)
    {
       var pedido = await _repository.AtualizarPedido(id,pedidoAtualizado);
        if(pedido==null)
        return NotFound();

        
        return Ok(pedido);
    }
    
    //metodo de deletar 
    //tem como parametro o id 
    //se fornecedorParaRemover não for encontedo, retorna not found (404)
    //caso contrario, retorna que foi realizada com sucesso, (204)
    [HttpDelete("{id}")]
    public async Task< ActionResult> Delete(int id)
    {
        var pedidoParaRemover = await _repository.DeletarPedido(id);
        if (pedidoParaRemover == null)
            return NotFound();
        
        
        return NoContent();
        }
}