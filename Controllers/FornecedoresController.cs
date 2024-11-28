using AS.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class FornecedoresController : Controller
{
   private readonly AppDbContext _context;

   public FornecedoresController(AppDbContext context)
   {
    _context = context;
   }

    [HttpGet]

    public ActionResult<List<Fornecedor>> Get()
    {
         return _context.Fornecedores.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Fornecedor> Get(int id)
    {
        var Fornecedor = _context.Fornecedores.Find(id);
        if (Fornecedor == null)
        {
            return NotFound();
        }
        return Fornecedor;
    }
    [HttpPost]
    public ActionResult Post(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        _context.SaveChanges();
        return Created();
    }
    [HttpPut("{id}")]
    public ActionResult Put(int id, Fornecedor fornecedorAtualizado)
    {
        var Fornecedor = _context.Fornecedores.Find(id);
        if (Fornecedor == null)
        {
            return NotFound();
        }
        Fornecedor.Id = fornecedorAtualizado.Id;
        Fornecedor.Nome = fornecedorAtualizado.Nome;
        Fornecedor.CNPJ = fornecedorAtualizado.CNPJ;
        Fornecedor.Telefone = fornecedorAtualizado.Telefone;
        Fornecedor.Email = fornecedorAtualizado.Email;
        Fornecedor.Endereco = fornecedorAtualizado.Endereco;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var fornecedorRemover = _context.Fornecedores.Find(id);
        if (fornecedorRemover == null)
        {
            return NotFound();
        }
        _context.Fornecedores.Remove(fornecedorRemover);
        _context.SaveChanges();
        return NoContent();
    }
}