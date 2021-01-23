	public class DataTableRequest
    {
        public string sEcho { get; set; }
        public int iColumns { get; set; }
        public string sColumns { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public bool bRegex { get; set; }
        public int iSortingCols { get; set; }
        public List<DataTableColumnActions> Columns { get; set; }
        public List<DataTableSort> Sorts { get; set; }
        public IEnumerable<TResult> ToList<T, TResult>(IQueryable<T> Data, Expression<Func<T, TResult>> selector) where T : class where TResult : class
        {
            if (string.IsNullOrEmpty(sSearch) == false)
            {
                Data = Data.Filter(sSearch);
            }
            IQueryable<TResult> result = Data.Select(selector);
            if (Sorts.Count > 0 && Columns.Count > 0)
            {
                foreach (var sort in Sorts)
                {
                    var column = Columns[sort.iSortCol];
                    result = result.OrderBy(column.mDataProp + " " + sort.sSortDir);
                }
            }
            return result.Skip(iDisplayStart).Take(iDisplayLength).AsEnumerable();
        }
        public IEnumerable<T> ToList<T>(IQueryable<T> Data) where T : class
        {
            var result = Data;
            if (string.IsNullOrEmpty(sSearch) == false)
            {
                result = result.Filter(sSearch);
            }
            if (Sorts.Count > 0 && Columns.Count > 0)
            {
                foreach (var sort in Sorts)
                {
                    var column = Columns[sort.iSortCol];
                    result = result.OrderBy(column.mDataProp + " " + sort.sSortDir);
                }
            }
            return result.Skip(iDisplayStart).Take(iDisplayLength).AsEnumerable();
        }
        public object ToDataTableResult<T, TResult>(IQueryable<T> Data, Expression<Func<T, TResult>> selector) where T : class where TResult : class
        {
            IQueryable<T> inData = Data;
            if (string.IsNullOrEmpty(sSearch) == false)
            {
                inData = inData.Filter(sSearch);
            }
            IQueryable<TResult> result = inData.Select(selector);
            if (Sorts.Count > 0 && Columns.Count > 0)
            {
                foreach (var sort in Sorts)
                {
                    var column = Columns[sort.iSortCol];
                    result = result.OrderBy(column.mDataProp + " " + sort.sSortDir);
                }
            }
            return new
            {
                draw = sEcho,
                recordsTotal = Data.Count(),
                recordsFiltered = result.Count(),
                data = result.Skip(iDisplayStart).Take(iDisplayLength).AsEnumerable()
            };
        }
        public object ToDataTableResult<T>(IQueryable<T> Data) where T : class
        {
            var result = Data;
            if (string.IsNullOrEmpty(sSearch) == false)
            {
                result = result.Filter(sSearch);
            }
            if (Sorts.Count > 0 && Columns.Count > 0)
            {
                foreach (var sort in Sorts)
                {
                    var column = Columns[sort.iSortCol];
                    result = result.OrderBy(column.mDataProp + " " + sort.sSortDir);
                }
            }
            return new
            {
                draw = sEcho,
                recordsTotal = Data.Count(),
                recordsFiltered = result.Count(),
                data = result.Skip(iDisplayStart).Take(iDisplayLength).AsEnumerable()
            };
        }
    }
    public class DataTableColumnActions
    {
        public string mDataProp { get; set; }
        public string sSearch { get; set; }
        public bool bRegex { get; set; }
        public bool bSearchable { get; set; }
        public bool bSortable { get; set; }
    }
    public class DataTableSort
    {
        public int iSortCol { get; set; }
        public string sSortDir { get; set; }
    }
	public class DataTableRequestProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Metadata.ModelType == typeof(DataTableRequest))
                return new DataTableRequestBinder();
            return null;
        }
        public class DataTableRequestBinder : Attribute, IModelBinder
        {
            public async Task BindModelAsync(ModelBindingContext bindingContext)
            {
                await Task.Run(() =>
                {
                    int index;
                    var request = new DataTableRequest();
                    request.bRegex = Convert.ToBoolean(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "bRegex").Select(i => i.Value.ToString()).FirstOrDefault());
                    request.sSearch = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "sSearch").Select(i => i.Value.ToString()).FirstOrDefault();
                    request.sEcho = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "sEcho").Select(i => i.Value.ToString()).FirstOrDefault();
                    request.sColumns = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "sColumns").Select(i => i.Value.ToString()).FirstOrDefault();
                    request.iColumns = Convert.ToInt32(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "iColumns").Select(i => i.Value.ToString()).FirstOrDefault());
                    request.iDisplayLength = Convert.ToInt32(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "iDisplayLength").Select(i => i.Value.ToString()).FirstOrDefault());
                    request.iDisplayStart = Convert.ToInt32(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "iDisplayStart").Select(i => i.Value.ToString()).FirstOrDefault());
                    request.iSortingCols = Convert.ToInt32(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "iSortingCols").Select(i => i.Value.ToString()).FirstOrDefault());
                    request.Sorts = new List<DataTableSort>();
                    request.Columns = new List<DataTableColumnActions>();
                    index = 0;
                    while (bindingContext.HttpContext.Request.Query.Keys.Any(k => k == "iSortCol_" + index))
                    {
                        var sort = new DataTableSort();
                        sort.iSortCol = Convert.ToInt32(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "iSortCol_" + index).Select(i => i.Value.ToString()).FirstOrDefault());
                        sort.sSortDir = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "sSortDir_" + index).Select(i => i.Value.ToString()).FirstOrDefault();
                        request.Sorts.Add(sort);
                        index++;
                    }
                    index = 0;
                    while (bindingContext.HttpContext.Request.Query.Keys.Any(k => k == "mDataProp_" + index))
                    {
                        var column = new DataTableColumnActions();
                        column.bRegex = Convert.ToBoolean(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "bRegex_" + index).Select(i => i.Value.ToString()).FirstOrDefault());
                        column.bSearchable = Convert.ToBoolean(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "bSearchable_" + index).Select(i => i.Value.ToString()).FirstOrDefault());
                        column.bSortable = Convert.ToBoolean(bindingContext.HttpContext.Request.Query.Where(i => i.Key == "bSortable_" + index).Select(i => i.Value.ToString()).FirstOrDefault());
                        column.mDataProp = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "mDataProp_" + index).Select(i => i.Value.ToString()).FirstOrDefault();
                        column.sSearch = bindingContext.HttpContext.Request.Query.Where(i => i.Key == "sSearch_" + index).Select(i => i.Value.ToString()).FirstOrDefault();
                        request.Columns.Add(column);
                        index++;
                    }
                    bindingContext.Result = ModelBindingResult.Success(request);
                    return Task.CompletedTask;
                });
            }
        }
    }
    public static class IQueryableExtension
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByValues) where TEntity : class
        {
            IQueryable<TEntity> returnValue = null;
            string orderPair = orderByValues.Trim().Split(',')[0];
            string command = orderPair.ToUpper().Contains("DESC") ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");
            string propertyName = (orderPair.Split(' ')[0]).Trim();
            System.Reflection.PropertyInfo property;
            MemberExpression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields. 
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    Type t = property.PropertyType;
                    if (!t.IsConstructedGenericType)
                    {
                        property = t.GetProperty(childProperties[i]);
                    }
                    else
                    {
                        property = t.GetGenericArguments().First().GetProperty(childProperties[i]);
                    }
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
            source.Expression, Expression.Quote(orderByExpression));
            returnValue = source.Provider.CreateQuery<TEntity>(resultExpression);
            if (orderByValues.Trim().Split(',').Count() > 1)
            {
                // remove first item
                string newSearchForWords = orderByValues.ToString().Remove(0, orderByValues.ToString().IndexOf(',') + 1);
                return source.OrderBy(newSearchForWords);
            }
            return returnValue;
        }
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string search)
        {
            var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(String));
            var predicate = PredicateBuilder.New<T>(false);
            foreach (PropertyInfo property in properties)
            {
                predicate = predicate.Or(CreateLike<T>(property, search));
            }
            return query.AsExpandable().Where(predicate);
        }
        private static Expression<Func<T, bool>> CreateLike<T>(PropertyInfo prop, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "f");
            var propertyAccess = Expression.MakeMemberAccess(parameter, prop);
            // make sure string is not null
            var notNull = Expression.NotEqual(propertyAccess, Expression.Constant(null, typeof(string)));
            // convert to lower case
            var toLower = Expression.Call(propertyAccess, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            // comparison on lower case
            var like = Expression.Call(toLower, "Contains", null, Expression.Constant(value.ToLower(), typeof(string)));
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(notNull, like), parameter);
        }
    }
