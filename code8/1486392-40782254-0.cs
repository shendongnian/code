    public static class ReaderHelper
    {
        public static IEnumerable<TElem> GetData<TElem>(this IDataReader reader, Func<IDataRecord, TElem> buildObjectDelegat)
        {
            while (reader.Read())
            {
                yield return buildObjectDelegat(reader);
            }
        }
    }
    // ...
    var result = reader.GetData(x => new LocationInfo()
            {
                Names = x.GetString(0),
                Values = Math.Round(x.GetDouble(1), 2).ToString("#,##0.00"),
                ValuesDouble = x.GetDouble(1)
            }).Take(2);
