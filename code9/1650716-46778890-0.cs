    public class PagedQueryHandler<TQuery, TItem>
        : IQueryHandler<PagedQuery<TQuery, TItem>, Paged<TItem>>
        where TQuery : IQuery<IQueryable<TItem>>
    {
        private readonly IQueryHandler<TQuery, IQueryable<TItem>> handler;
        public PagedQueryHandler(IQueryHandler<TQuery, IQueryable<TItem>> handler)
        {
            this.handler = handler;
        }
        public Paged<TItem> Handle(PagedQuery<TQuery, TItem> query)
        {
            var paging = query.PageInfo ?? new PageInfo();
            IQueryable<TItem> items = this.handler.Handle(query.Query);
            return new Paged<TItem>
            {
                Items = items.Skip(paging.PageIndex * paging.PageSize)
                    .Take(paging.PageSize).ToArray(),
                Paging = paging,
            };
        }
    }
