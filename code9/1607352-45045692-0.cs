	static class Ext {
		public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query) {
			using (var db = GetContext(query)) {
				var workspace = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
				var itemCollection = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));
				var entityType = itemCollection.OfType<EntityType>().Single(e => itemCollection.GetClrType(e) == typeof(T));
	
				foreach (var navigationProperty in entityType.NavigationProperties)
					query = query.Include(navigationProperty.Name);
			}
	
			return query;
		}
	
		private static DataContext GetContext(IQueryable q) {
			if (!q.GetType().FullName.StartsWith("System.Data.Linq.DataQuery`1")) return null;
			var field = q.GetType().GetField("context", BindingFlags.NonPublic | BindingFlags.Instance);
			if (field == null) return null;
			return field.GetValue(q) as DataContext;
		}
	}
