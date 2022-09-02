

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IProductoRepository Productos { get; }
    IMarcaRepository Marca { get; }
    ICategoriaRepository Categorias { get; }

    int Save();
}
