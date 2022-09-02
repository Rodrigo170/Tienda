
using Core.Entities;

namespace API.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
    }
}
