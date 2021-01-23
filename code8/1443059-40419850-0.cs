    using System.Data.Entity;
    using System;
    namespace EF_Sample07.DataLayer.Context
    {
     public interface IUnitOfWork
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
       }
     }
