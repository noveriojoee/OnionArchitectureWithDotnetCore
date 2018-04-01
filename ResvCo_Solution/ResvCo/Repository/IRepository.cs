using System;
using System.Collections.Generic;
using ResvCo.Models;
namespace ResvCo.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();  
        
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
        void Remove(T entity);  
        void SaveChanges();  
    }
}
