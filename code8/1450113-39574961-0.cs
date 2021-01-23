    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    public class DbSetMock<T> : DbSet<T>, IDbSet<T>
        where T : class
    {
        private readonly ICollection<T> _contentCollection;
        public DbSetMock(IList<T> contentCollection = null)
        {
            _contentCollection = new Collection<T>(contentCollection ?? new List<T>());
            AddedEntities = new List<T>();
            RemovedEntities = new List<T>();
            AttachedEntities = new List<T>();
        }
        public void OverrideContentCollection(IEnumerable<T> newData)
        {
            _contentCollection.Clear();
            _contentCollection.AddRange(newData);
        }
        public IList<T> AddedEntities { get; private set; }
        public IList<T> AttachedEntities { get; private set; }
        public override ObservableCollection<T> Local
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IList<T> RemovedEntities { get; private set; }
        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }
        public Expression Expression
        {
            get
            {
                return _contentCollection.AsQueryable().Expression;
            }
        }
        public IQueryProvider Provider
        {
            get
            {
                return _contentCollection.AsQueryable().Provider;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _contentCollection.GetEnumerator();
        }
        public override T Add(T entity)
        {
            AddedEntities.Add(entity);
            _contentCollection.Add(entity);
            return entity;
        }
        public override T Attach(T entity)
        {
            AttachedEntities.Add(entity);
            var matchingEntity = _contentCollection.SingleOrDefault(x => x.Id == entity.Id);
            if (matchingEntity != null)
            {
                _contentCollection.Remove(matchingEntity);
            }
            _contentCollection.Add(entity);
            return entity;
        }
        public override TDerivedEntity Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }
        public override T Create()
        {
            throw new NotImplementedException();
        }
        public override T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }
        public override T Remove(T entity)
        {
            RemovedEntities.Add(entity);
            _contentCollection.Remove(entity);
            return entity;
        }
    }
