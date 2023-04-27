using MailApp.Models.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Models.Service
{
    public class Repository<T> : IRepository<T> where T : class, IEntityWithId
    {
        #region Dependency Injection
        private ObservableCollection<T> entities;
        public Repository(ObservableCollection<T> entities)
        {
            this.entities = entities;
        }
        #endregion
        #region Contract Methods
        public void Add(T entity)
        {
            entities.Add(entity);
        }
        public void Delete(T entity)
        {
            entities.Remove(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return entities;
        }
        public T GetById(Guid id)
        {
            return entities.FirstOrDefault(e => e.ID == id);
        }
        public void Update(T entity)
        {
            var existingEntity = entities.FirstOrDefault(e => ((IEntityWithId)e).ID == ((IEntityWithId)entity).ID);
            if (existingEntity != null)
            {
                entities.Remove(existingEntity);
                entities.Add(entity);
            }
        }
        #endregion
    }
}
