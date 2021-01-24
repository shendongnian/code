    public static class DastaxTableExtensions
    {
        public static void Drop<T>(this Table<T> table)
        {
            table.GetSession().Execute($"DROP TABLE {table.Name};");
		}
		public static void DropIfExists<T>(this Table<T> table)
		{
			table.GetSession().Execute($"DROP TABLE IF EXISTS {table.Name};");
		}
    }
