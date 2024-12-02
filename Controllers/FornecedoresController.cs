using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using SQLitePCL;
[ApiController]
//definição da rota base
[Route("[controller]")]

//classa FornecedorController que herda de controllerBase
public class FornecedoresController : ControllerBase
{

//campo privado e imutável
private readonly IFornecedoresRepository _repository;

//metodo construtor -- parametro repository
public FornecedoresController(IFornecedoresRepository repository)
{
    _repository = repository;
}
    //metodo de listar fornecedores 
    //async porque ele realiza operações assíncronas
    //Após obter a lista, retorna um Ok (200)
    [HttpGet]
    public async Task <ActionResult<List<Fornecedor>>> Get()
    {
        var fornecedores = await _repository.GetTodosFornecedores();
        return Ok(fornecedores);
    }
    //metodo listar por id
    //tem como parametro id
    //casa fornecedor não for encontrado, reotorna not found(404)
    [HttpGet("{id}")]
    public async Task< ActionResult<Fornecedor>> Get(int id)
    {
       var fornecedor = await _repository.GetFornecedor(id);
        
        if (fornecedor == null)
            return NotFound();
        
        return Ok(fornecedor);

    }
    //metodo de criar
    //chama o metodo de criar fornecedor e retorna created 
    [HttpPost]
    public async Task <ActionResult> Post(Fornecedor fornecedor)
    {
        await _repository.AdicionarFornecedor(fornecedor);
        return Created();
    }

    //metodo de editar fornecedor
    //chama o metodo de atualezar fornecedor que me como parametro id  e fornecedorAtualizado
    //se fornecedor não for encontrado, retona not found (404)
    //caso contrario, retorna ok (200)
    [HttpPut("{id}")]
    public async Task <ActionResult<Fornecedor>> Put(int id, Fornecedor fornecedorAtualizado)
    {
       var fornecedor = await _repository.AtualizarFornecedor(id,fornecedorAtualizado);
        if(fornecedor==null)
        return NotFound();

        
        return Ok(fornecedor);
    }
    //metodo de deletar 
    //tem como parametro o id 
    //se fornecedorParaRemover não for encontedo, retorna not found (404)
    //caso contrario, retorna que foi realizada com sucesso, (204)
    [HttpDelete("{id}")]
    public async Task< ActionResult> Delete(int id)
    {
        var fornecedorParaRemover = await _repository.DeletarFornecedor(id);
        if (fornecedorParaRemover == null)
            return NotFound();
        
        
        return NoContent();




    }
}