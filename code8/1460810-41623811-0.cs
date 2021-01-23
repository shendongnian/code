    public class CustomResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            return source.New(Convert.ChangeType((source.Context.SourceValue as DataRow)[source.Context.MemberName], source.Context.DestinationType));
        }
    }
    public static class DtoTransformDataTable<T> where T : new()
    {
        public static IEnumerable<T> JustDoIt(DataTable dt)
        {
            Mapper.CreateMap<DataRow, T>().ForAllMembers(m => m.ResolveUsing<CustomResolver>());
            var listOfT = new List<T>();
            foreach (var item in dt.Rows) //Use LINQ to concise
            {
                var dest = Mapper.Map<T>(item);
                listOfT.Add(dest);
            }
            return listOfT;
        }
    }
