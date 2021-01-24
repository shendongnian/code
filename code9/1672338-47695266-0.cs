    class Example
    {
        static void Main()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap(typeof(PagedList<>), typeof(IPagedList<>))
                     .ConvertUsing(typeof(Converter<,>));
                config.CreateMap<Entity, DTO>();
            });
            var entityList = new PagedList<Entity>(new [] { new Entity(), }, new PagingInformation() { Total =  2, PageNumber =  1, PageSize = 10});
            var mapped = Mapper.Map<IPagedList<DTO>>(entityList);
        }
    }
    class Converter<Ts, Td> : ITypeConverter<IPagedList<Ts> , IPagedList<Td>>
    {
        public IPagedList<Td> Convert(IPagedList<Ts> source, IPagedList<Td> destination, ResolutionContext context)
        {
            return new PagedList<Td>(source.AsEnumerable().Select(x => context.Mapper.Map<Td>(x)), source.Paging);
        }
    }
    
    class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
    class DTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
    public interface IPagedList<T> : IList<T>
    {
        PagingInformation Paging { get; set; }
    }
    public class PagingInformation
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagingInformation Paging { get; set; }
        public PagedList() { }
        public PagedList(IEnumerable<T> collection) : base(collection) { }
        public PagedList(IEnumerable<T> collection, PagingInformation paging) : base(collection) { Paging = paging; }
    }
