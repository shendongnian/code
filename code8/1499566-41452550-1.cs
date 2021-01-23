    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Reestr.DAL.DB;
    using Reestr.DAL.Entities;
    using Reestr.DAL.Helpers;
    using ServiceStack.OrmLite;
    
    namespace Reestr.DAL.Repositories
    {
        internal class PersonRepository : Repository<Person>
        {
            private ReestrContext db;
            private readonly MethodFinder finder;
    
            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
            /// </summary>
            public PersonRepository(ReestrContext db) : base(db)
            {
                this.db = db;
                finder = new MethodFinder(db);
            }
    
            public override Person GetById(long id)
            {
                Person p = base.GetById(id);
                List<Dic> dics = db.Connection.Select<Dic>();
                foreach (Subject subject in p.Subjects)
                {
                    subject.Parent = dics.FirstOrDefault(dic => dic.DicCode == subject.ParentDicCode);
                    subject.Child = dics.FirstOrDefault(dic => dic.DicCode == subject.ChildDicCode);
                }
                return p;
            }
    
            public override long CountByCondition(Expression<System.Func<Person, bool>> predicate)
            {
                ResolveNestedConditions(predicate);
                if (finder.IsNestedPocoExist)
                {
                    return base.CountByCondition(finder.GetRegeneratedPredicate<Person>());
                }
                return base.CountByCondition(predicate);
            }
    
            public override IQueryable<Person> GetByCondition(Expression<System.Func<Person, bool>> predicate)
            {
                ResolveNestedConditions(predicate);
                if (finder.IsNestedPocoExist)
                {
                    return base.GetByCondition(finder.GetRegeneratedPredicate<Person>());
                }
                return base.GetByCondition(predicate);
            }
    
            public override IQueryable<Person> GetByCondition(Expression<System.Func<Person, bool>> predicate, int rows)
            {
                ResolveNestedConditions(predicate);
                if (finder.IsNestedPocoExist)
                {
                    return base.GetByCondition(finder.GetRegeneratedPredicate<Person>(), rows);
                }
                return base.GetByCondition(predicate, rows);
            }
    
            public override IQueryable<Person> GetByCondition(Expression<System.Func<Person, bool>> predicate, int? skip, int? rows)
            {
                ResolveNestedConditions(predicate);
                if (finder.IsNestedPocoExist)
                {
                    return base.GetByCondition(finder.GetRegeneratedPredicate<Person>(), skip, rows);
                }
                return base.GetByCondition(predicate, skip, rows);
            }
    
            private void ResolveNestedConditions(Expression<System.Func<Person, bool>> predicate)
            {
                finder.DoVisiting(predicate);
            }
        }
    }
