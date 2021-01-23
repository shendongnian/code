    class Program
    {
        #region Copied from Expression.Call question
        static MethodBase GetGenericMethod(Type type, string name, Type[] typeArgs, Type[] argTypes, BindingFlags flags)
        {
            int typeArity = typeArgs.Length;
            var methods = type.GetMethods()
                .Where(m => m.Name == name)
                .Where(m => m.GetGenericArguments().Length == typeArity)
                .Select(m => m.MakeGenericMethod(typeArgs));
            return Type.DefaultBinder.SelectMethod(flags, methods.ToArray(), argTypes, null);
        }
        static bool IsIEnumerable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
        static Type GetIEnumerableImpl(Type type)
        {
            // Get IEnumerable implementation. Either type is IEnumerable<T> for some T, 
            // or it implements IEnumerable<T> for some T. We need to find the interface.
            if (IsIEnumerable(type))
                return type;
            Type[] t = type.FindInterfaces((m, o) => IsIEnumerable(m), null);
            Debug.Assert(t.Length == 1);
            return t[0];
        }
        static Expression CallAny(Expression collection, Expression predicateExpression)
        {
            Type cType = GetIEnumerableImpl(collection.Type);
            collection = Expression.Convert(collection, cType); // (see "NOTE" below)
            Type elemType = cType.GetGenericArguments()[0];
            Type predType = typeof(Func<,>).MakeGenericType(elemType, typeof(bool));
            // Enumerable.Any<T>(IEnumerable<T>, Func<T,bool>)
            MethodInfo anyMethod = (MethodInfo)
                GetGenericMethod(typeof(Enumerable), "Any", new[] { elemType },
                    new[] { cType, predType }, BindingFlags.Static);
            return Expression.Call(anyMethod, collection, predicateExpression);
        }
        #endregion
        public class TestEntity
        {
            public int Id { get; set; }
            public TestEntity[] Value { get; set; }
        }
        private static TestEntity CreateTestEntity(int id, params TestEntity[] values)
        {
            return new TestEntity { Id = id, Value = values };
        }
        static void Main(string[] args)
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("TestEntities");
            IMongoCollection<TestEntity> collection = db.GetCollection<TestEntity>("Entities");
            collection.InsertOne(CreateTestEntity(1, CreateTestEntity(2, CreateTestEntity(3, CreateTestEntity(4)))));
            const int selectedId = 4;
            int searchDepth = 6;
            // builds the expression tree of expanding x => x.Value.Any(...)
            var filter = GetFilterForDepth(selectedId, searchDepth);
            var testEntity = collection.Find(filter).FirstOrDefault();
            if (testEntity != null)
            {
                UpdateItem(testEntity, selectedId);
                collection.ReplaceOne(filter, testEntity);
            }
        }
        private static bool UpdateItem(TestEntity testEntity, int selectedId)
        {
            if (testEntity.Id == selectedId)
            {
                return true;
            }
            if (UpdateItem(testEntity.Value[0], selectedId))
                testEntity.Value[0] = CreateTestEntity(11);
            return false;
        }
        private static FilterDefinition<TestEntity> GetFilterForDepth(int id, int depth)
        {
            var idEqualsParam = Expression.Parameter(typeof(TestEntity), "item");
            var idProp = Expression.Property(idEqualsParam, "Id");
            var idEquals = Expression.Equal(idProp, Expression.Constant(id));
            var idEqualsLambda = Expression.Lambda<Func<TestEntity, bool>>(idEquals, idEqualsParam);
            var anyParam = Expression.Parameter(typeof(TestEntity), "x");
            var valueProp = Expression.Property(anyParam, "Value");
            // Expression.Call would not find easily the appropriate .Any((TestEntity x) => x == id) 
            var callAny = CallAny(valueProp, idEqualsLambda);
            var firstAny = Expression.Lambda<Func<TestEntity, bool>>(callAny, anyParam);
            return NestedFilter(Builders<TestEntity>.Filter.Eq(x => x.Id, id), firstAny, depth);
        }
        static int paramIndex = 0;
        private static FilterDefinition<TestEntity> NestedFilter(FilterDefinition<TestEntity> actual, Expression<Func<TestEntity, bool>> whereExpression, int depth)
        {
            if (depth == 0)
            {
                return actual;
            }
            var param = Expression.Parameter(typeof(TestEntity), "param" + paramIndex++);
            var valueProp = Expression.Property(param, "Value");
            var valueLambda = Expression.Lambda<Func<TestEntity, IEnumerable<TestEntity>>>(valueProp, param);
            var callLambda = Expression.Lambda<Func<TestEntity, bool>>(CallAny(valueLambda.Body, whereExpression), param);
            return NestedFilter(Builders<TestEntity>.Filter.Where(whereExpression), callLambda, depth - 1) | actual;
        }
    }
