	public class Program
	{
		static void Main(string[] args)
		{
			var data = new List<Test>()
			{
				new Test() {ID = 1, Name = "1Text"},
				new Test() {ID = 2, Name = "2Text"},
			};
			var action = ExpressionHelper.GetAction<Test>();
			var dataTable = new DataTable();
			action(dataTable, data);
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
			}
		}
	}
	public class ExpressionHelper
	{
		public static Action<DataTable, IEnumerable<T>> GetAction<T>()
		{
			//if (_filler != null)
			//	return null;
			var type = typeof(T);
			var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var tableParam = Expression.Parameter(typeof(DataTable), "targetTable");
			var rowsParam = Expression.Parameter(typeof(IEnumerable<T>), "rows");
			var loopVariable = Expression.Parameter(typeof(T), "item");
			var columnsVariable = Expression.Parameter(typeof(DataColumnCollection), "columns");
			var columnsAssign = Expression.Assign(columnsVariable,
				Expression.Property(tableParam, typeof(DataTable).GetProperty("Columns")));
			var headerExpressions = new List<Expression>();
			var bodyExpressions = new List<Expression>();
			var headerNameParam = Expression.Parameter(typeof(string), "columnName");
			var headerTypeParam = Expression.Parameter(typeof(Type), "columnType");
			var newRowParam = Expression.Parameter(typeof(DataRow), "currentRow");
			var newRowAssign = Expression.Assign(newRowParam, Expression.Call(tableParam, typeof(DataTable).GetMethod("NewRow")));
			bodyExpressions.Add(newRowAssign);
			foreach (var prop in props)
			{
				var getMethod = prop.GetGetMethod(false);
				if (getMethod == null)
					continue;
				var attr = prop.GetCustomAttribute<UdtColumnAttribute>();
				var name = attr == null ? prop.Name : attr.ColumnName;
				var headerNameAssign = Expression.Assign(headerNameParam, Expression.Constant(name, typeof(string)));
				var headerTypeAssign = Expression.Assign(headerTypeParam, Expression.Constant(prop.PropertyType, typeof(Type)));
				var columnsAddMethod = Expression.Call(columnsVariable,
					typeof(DataColumnCollection).GetMethod("Add", new[] { typeof(string), typeof(Type) }),
					headerNameParam, headerTypeParam);
				headerExpressions.AddRange(new Expression[] {
										   headerNameAssign,
										   headerTypeAssign,
										   columnsAddMethod,
									   });
				var indexerProp = typeof(DataRow).GetProperty("Item", new[] { typeof(string) });
				var indexerParam = Expression.Property(newRowParam, indexerProp, Expression.Constant(name, typeof(string)));
				var propertyReaderMethod = Expression.Call(loopVariable, getMethod);
				var assign = Expression.Assign(indexerParam, Expression.TypeAs(propertyReaderMethod, typeof(object)));
				bodyExpressions.AddRange(new Expression[] { assign });
			}
			// we should add that row back to collection
			var addRow = Expression.Call(
				Expression.Property(tableParam, "Rows"),
				typeof(DataRowCollection).GetMethod("Add", new Type[] {typeof(DataRow)}),
				newRowParam);
			bodyExpressions.Add(addRow);
			var finalExpressions = new List<Expression>()
			{
				columnsAssign,
				newRowAssign,
			};
			var variables = new List<ParameterExpression>()
			{
				loopVariable,
				columnsVariable,
				newRowParam,
				headerNameParam,
				headerTypeParam
			};
			finalExpressions.AddRange(headerExpressions);
			var loop = ExpressionHelper.ForEach(rowsParam, loopVariable, Expression.Block(bodyExpressions));
			finalExpressions.Add(loop);
			var compilable = Expression.Block(variables, finalExpressions);
			var code = compilable.ToString();
			Trace.WriteLine(code);
			var compiled = Expression.Lambda<Action<DataTable, IEnumerable<T>>>(compilable, tableParam, rowsParam).Compile();
			return compiled;
		}
		public static Expression ForEach(Expression collection, ParameterExpression loopVar, Expression loopContent)
		{
			var elementType = loopVar.Type;
			var enumerableType = typeof(IEnumerable<>).MakeGenericType(elementType);
			var enumeratorType = typeof(IEnumerator<>).MakeGenericType(elementType);
			var enumeratorVar = Expression.Variable(enumeratorType, "enumerator");
			var getEnumeratorCall = Expression.Call(collection, enumerableType.GetMethod("GetEnumerator"));
			var enumeratorAssign = Expression.Assign(enumeratorVar, getEnumeratorCall);
			// The MoveNext method's actually on IEnumerator, not IEnumerator<T>
			var moveNextCall = Expression.Call(enumeratorVar, typeof(IEnumerator).GetMethod("MoveNext"));
			var breakLabel = Expression.Label("LoopBreak");
			var loop = Expression.Block(new[] { enumeratorVar },
				enumeratorAssign,
				Expression.Loop(
					Expression.IfThenElse(
						Expression.Equal(moveNextCall, Expression.Constant(true)),
						Expression.Block(new[] { loopVar },
							Expression.Assign(loopVar, Expression.Property(enumeratorVar, "Current")),
							loopContent
						),
						Expression.Break(breakLabel)
					),
				breakLabel)
			);
			return loop;
		}
	}
	public class Test
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
	public class UdtColumnAttribute : Attribute
	{
		public string ColumnName { get; set; }
	}
