using AS.Data;
using Microsoft.EntityFrameworkCore;

//classe que herda da interface IFornecedoresRepository
public class FornecedoresRepository : IFornecedoresRepository
{
    // Campo privado para acessar o contexto do banco de dados
    private readonly AppDbContext _context;
     // Construtor que recebe o AppDbContext via injeção de dependência
    public FornecedoresRepository(AppDbContext context)
    {
        _context = context;
    }
    //async == metodo assincrono
    // Método assíncrono para adicionar um novo fornecedor
    public async Task AdicionarFornecedor(Fornecedor fornecedor)
    {
        // Adiciona o fornecedor à tabela Fornecedores
        await _context.Fornecedores.AddAsync(fornecedor);
        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
    }
    // Método assíncrono para edita os dados de um fornecedor
    public async Task<Fornecedor> AtualizarFornecedor(int id, Fornecedor fornecedorAtualizado)
    {
        // Busca o fornecedor pelo ID no banco
        var fornecedor = await _context.Fornecedores.FindAsync(id);
         if (fornecedor == null)
         return fornecedor;

         // Atualiza os dados do fornecedor com os novos valores fornecidos
        fornecedor.Nome = fornecedorAtualizado.Nome;
        fornecedor.CNPJ = fornecedorAtualizado.CNPJ;
        fornecedor.Telefone = fornecedorAtualizado.Telefone;
        fornecedor.Email = fornecedorAtualizado.Email;
        fornecedor.Endereco = fornecedorAtualizado.Endereco;

        //Salve e retorna o fornecedor atualizado
        await _context.SaveChangesAsync();
        return fornecedor;
       
    }

    // Método assíncrono para deletar um fornecedor pelo ID
    public async Task<Fornecedor> DeletarFornecedor(int id)
    {
        // Busca o fornecedor pelo ID no banco
        var fornecedor = await _context.Fornecedores.FindAsync(id);
         if (fornecedor == null)
            return fornecedor;
        
         // Remove o fornecedor do banco de dados, salva e retorna que o fornecedor foi deletado
        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }
    // Método assíncrono para buscar um fornecedor pelo ID
    public async Task<Fornecedor> GetFornecedor(int id)
    {
        // Retorna o fornecedor encontrado ou null se não existir
        return await _context.Fornecedores.FindAsync(id);
    }

     // Método assíncrono para buscar todos os fornecedores
    public async Task<List<Fornecedor>> GetTodosFornecedores()
    {
        // Retorna uma lista de todos os fornecedores
        return await _context.Fornecedores.ToListAsync();
        
    }
}