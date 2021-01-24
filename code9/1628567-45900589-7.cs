     In this implementation your DTO would look something like:
        public class SqlGeographyDTO
        {
            const int DefaultSRID = 4326; // TODO: check if this is the correct default.
            public int? STSrid { get; set; }
            public string Geography { get; set; }
            public static implicit operator SqlGeographyDTO(SqlGeography geography)
            {
                if (geography == null || geography.IsNull)
                    return null;
                return new SqlGeographyDTO
                {
                    STSrid = geography.STSrid.IsNull ? (int?)null : geography.STSrid.Value,
                    Geography = geography.ToString(),
                };
            }
            public static implicit operator SqlGeography(SqlGeographyDTO dto)
            {
                if (dto == null)
                    return SqlGeography.Null;
                var geography = SqlGeography.STGeomFromText(new SqlChars(dto.Geography), dto.STSrid.GetValueOrDefault(DefaultSRID));
                return geography;
            }
        }
    Again this implementation might lose precision, but has the advantage of being usable with many formats and serializers including JSON and Json.NET.  This seems to be the approach used by [`ServiceStack.OrmLite.SqlServer.Converters/SqlServerGeographyTypeConverter`](https://github.com/ServiceStack/ServiceStack.OrmLite/blob/master/src/ServiceStack.OrmLite.SqlServer.Converters/SqlServerGeographyTypeConverter.cs), for instance.
    Working [.Net fiddle](https://dotnetfiddle.net/HVLKcT) courtesy of @M.Hassan.
