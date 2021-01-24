    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using Repositorio.DAL.Contexto;
    namespace Repositorio.DAL.Repositorios.Base
    {
    public abstract class Repositorio<TEntity> : IDisposable,
       IRepositorio<TEntity> where TEntity : class
    {
        BancoContexto ctx = new BancoContexto();
        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }
        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }
        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }
        public void Atualizar(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }
        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }
        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }
        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }
        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
