public interface IFornecedoresRepository
{
    // Método assíncrono para listar todos os fornecedores.
    public Task<List<Fornecedor>> GetTodosFornecedores();
    // Método assíncrono para listar fornecedor pelo ID.
    public Task<Fornecedor> GetFornecedor(int id);
    // Método assíncrono para adicionar um novo fornecedor.
    public Task AdicionarFornecedor(Fornecedor fornecedor);
    // Método assíncrono para editar as informações de um fornecedor existente.
    public Task<Fornecedor> AtualizarFornecedor(int id, Fornecedor fornecedorAtualizado);
    // Método assíncrono para deletar um fornecedor pelo ID.
    public Task<Fornecedor> DeletarFornecedor(int id);
}