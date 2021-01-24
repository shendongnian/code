        public static EnumerableRowCollection<DataRow> CustomFilter(this DataTable @this,
            IEnumerable<Tuple<string, IEnumerable<string>>> filters)
        {
            var dataTemp = @this.AsEnumerable();
            return filters.Aggregate(dataTemp, 
                (current, filter) => current.Where(row => filter.Item2.Contains(row.Field<string>(filter.Item1))));
        }
