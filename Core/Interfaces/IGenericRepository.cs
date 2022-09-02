using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    /*
    TODAS LAS CLASES CON BASEENTITY USRAN ESTA CLASE
    */
    Task<T> GetByIdAsync(int id); //OBTIENE UNA IDENTIDAD POR IDENTIFICADOR
    Task<IEnumerable<T>> GetAllAsync(); //OBTIENE TODOS LOS RECUROS
    IEnumerable<T> Find(Expression<Func<T, bool>> expression); //REGRESA UN CONJUNTO DE REGISTROS
    void Add(T entity); //AGREGA UN ELEMENTO
    void AddRange(IEnumerable<T> entities); //AGREGA UNA LISTA AL CONTEXTO
    void Remove(T entity); //ELIMNA
    void RemoveRange(IEnumerable<T> entities); //ELIMNA UNA LISTA DE ENTIDADES EN EL CONTEXTO
    void Update(T entity);


}
