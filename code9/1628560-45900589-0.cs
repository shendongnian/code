        public class SqlGeographyDTO
        {
            const int DefaultSRID = 4326; // TODO: check if this is the correct default.
            public SqlInt32 STSrid { get; set; }
            public SqlXml Geography { get; set; }
            public static implicit operator SqlGeographyDTO(SqlGeography geography)
            {
                if (geography == null || geography.IsNull)
                    return null;
                return new SqlGeographyDTO
                {
                    STSrid = geography.STSrid,
                    Geography = geography.AsGml(),
                };
            }
            public static implicit operator SqlGeography(SqlGeographyDTO dto)
            {
                if (dto == null)
                    return SqlGeography.Null;
                var geometry = SqlGeography.GeomFromGml(dto.Geography, dto.STSrid.IsNull ? DefaultSRID : dto.STSrid.Value);
                return geometry;
            }
        }
     Since [`SqlXml`](https://msdn.microsoft.com/en-us/library/system.data.sqltypes.sqlxml.aspx) and [`SqlInt32`](https://msdn.microsoft.com/en-us/library/system.data.sqltypes.sqlint32.aspx) both implement `IXmlSerializable` this DTO can be serialized successfully by `XmlSerializer` and `DataContractSerializer`.  In addition since GML is an XML-based format the result will be parsable by any XML parser.  Note, however, that conversion from and to GML is documented not to be precise.
