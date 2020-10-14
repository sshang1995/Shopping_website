using System;
using System.Collections.Generic;
using Joole.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;

namespace Joole.Repo
{
    public class Repository<T> : IRepository<T> where T: class
    {
        
        protected JooleDatabaseEntities db = new JooleDatabaseEntities();
        protected DbSet<T> entities;
        public Repository() {
            entities = db.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            
            return entities.AsEnumerable();
        }
        public void Delete(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            db.SaveChanges();
            
        }

        public virtual T Get(long id)
        {
            T entity = entities.Find(id);
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            return entity;
        }

        

        public void Insert(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            db.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        
    }
}
