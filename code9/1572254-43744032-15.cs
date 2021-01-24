		public String GetJson(XmlDocument xml)
		{
            var sb = new StringBuilder();
            using (var textWriter = new StringWriter(sb))
			// Use Newtonsoft.Json.Formatting.None in your production code
			using (var writer = new NoCommentJsonTextWriter(textWriter) { Formatting = Newtonsoft.Json.Formatting.Indented })
            {
                JsonSerializer.CreateDefault().Serialize(writer, xml);
            }
            return sb.ToString();
		}		
