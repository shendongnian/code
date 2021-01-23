    public interface IElement
            {
                Guid Id { get; }
                string JobDescription { get; }
            }
    
            public Element[] GetByIds<T>(IQueryable<T> myPredicateContext, Guid[] ids) where T:IElement
            {
                return (from element in myPredicateContext
                        where ids.Contains(element.Id)
                        select new Element
                                        {
                                            Id = element.Id,
                                            Description = element.JobDescription,
                                        }).ToArray();
    
            }
