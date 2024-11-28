using AS.Data;
using Microsoft.EntityFrameworkCore;

public class FornecedoresRepository : IFornecedoresReposutory
{
    private readonly AppDbContext _context;
    public FornecedoresRepository(AppDbContext context)
    {
        _context = context;
    }
    //async == metodo assincrono
    public async Task AdicionarFornecedor(Fornecedor fornecedor)
    {
        await _context.Fornecedores.AddAsync(fornecedor);
        await _context.SaveChangesAsync();
    }

    public async Task<Fornecedor> AtualizarFornecedor(int id, Fornecedor fornecedorAtualizado)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
         if (fornecedor == null)
         return fornecedor;

        fornecedor.Id = fornecedorAtualizado.Id;
        fornecedor.Nome = fornecedorAtualizado.Nome;
        fornecedor.CNPJ = fornecedorAtualizado.CNPJ;
        fornecedor.Telefone = fornecedorAtualizado.Telefone;
        fornecedor.Email = fornecedorAtualizado.Email;
        fornecedor.Endereco = fornecedorAtualizado.Endereco;

        await _context.SaveChangesAsync();
        return fornecedor;
       
    }

    public async Task<Fornecedor> DeletarFornecedor(int id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
         if (fornecedor == null)
            return fornecedor;
        
        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }

    public async Task<Fornecedor> GetFornecedor(int id)
    {
        return await _context.Fornecedores.FindAsync(id);
    }

    public async Task<List<Fornecedor>> GetTodosFornecedores()
    {
        return await _context.Fornecedores.ToListAsync();
        
    }
}