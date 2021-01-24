    	public class SqlGeographyDTO
    	{
    		const int DefaultSRID = 4326; // TODO: check if this is the correct default.
    	
    		public int? STSrid { get; set; }
    	
    		public XElement Geography { get; set; }
    	
    		public static implicit operator SqlGeographyDTO(SqlGeography geography)
    		{
    			if (geography == null || geography.IsNull)
    				return null;
    			return new SqlGeographyDTO
    			{
    				STSrid = geography.STSrid.IsNull ? (int?)null : geography.STSrid.Value,
    				Geography = geography.AsGml().ToXElement(),
    			};
    		}
    	
    		public static implicit operator SqlGeography(SqlGeographyDTO dto)
    		{
    			if (dto == null)
    				return SqlGeography.Null;
    			var sqlXml = dto.Geography.ToSqlXml();
    			var geography = SqlGeography.GeomFromGml(sqlXml, dto.STSrid.GetValueOrDefault(DefaultSRID));
    			return geography;
    		}
    		
    		public override string ToString()
    		{
    			return Geography == null ? "" : Geography.ToString(SaveOptions.DisableFormatting);
    		}
    	}
    	
    	public static class XNodeExtensions
    	{
    		public static SqlXml ToSqlXml(this XNode node)
    		{
    			if (node == null)
    				return SqlXml.Null;
    			using (var reader = node.CreateReader())
    			{
    				return new SqlXml(reader);
    			}
    		}
    	}
    	
    	public static class SqlXmlExtensions
    	{
    		public static XElement ToXElement(this SqlXml sql)
    		{
    			if (sql == null || sql.IsNull)
    				return null;
    			using (var reader = sql.CreateReader())
    				return XElement.Load(reader);
    		}
    	}
     Since GML is an XML-based format the result will be parsable by any XML parser.  Note, however, that conversion from and to GML is documented not to be precise.
     Working [.Net fiddle](https://dotnetfiddle.net/iRhmwN).
     (As an aside: `AsGml()` returns an object of type [`SqlXml`](https://github.com/Microsoft/referencesource/blob/master/System.Data/System/Data/SQLTypes/SqlXml.cs) which implements `IXmlSerializable`, so it would seem possible to include the returned `SqlXml` directly in the DTO.  Unfortunately, testing reveals that either `AsGml()` or [`SqlXml.WriteXml()`](https://msdn.microsoft.com/en-us/library/bb506314(v=vs.110).aspx) seem to have a bug: an XML declaration is always included, even when the XML is being written as a nested child element of an outer container element. Thus the resulting, serialized XML will be nonconformant and broken.  Parsing to an intermediate `XElement` avoids this bug by stripping the unwanted declaration.)
