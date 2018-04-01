using System;  
using System.Collections.Generic;  
using System.Linq; 
using Microsoft.EntityFrameworkCore;

using ResvCo.Db;
using ResvCo.Models;
using ResvCo.Repository;

namespace ResvCo.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly ApplicationContext _context;
        private DbSet<T> _entities;

        private string _errorMessage;

        public Repository(ApplicationContext context)
        {
            this._context = context;
            this._entities = this._context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (this._entities == null){
                this._errorMessage = "entities not set";
                throw new NotImplementedException();   
            }
            this._entities.Remove(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this._entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (this._entities == null){
                this._errorMessage = "entities not set";
                throw new NotImplementedException();
            }
            this._entities.Add(entity);
            this._context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (this._entities == null){
                this._errorMessage = "entities not set";
                throw new NotImplementedException();
            }
            this._entities.Remove(entity);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
