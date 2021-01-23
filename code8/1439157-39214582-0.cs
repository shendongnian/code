    public class EvaluationStatJsonConverter : JsonConverter
    	{
    		public override bool CanConvert( Type objectType ) { return objectType == typeof( DeserializedJsonClass ); }
    
    		public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
    		{
    			var jsonObject = JObject.Load( reader );
    			var properties = typeof( EvaluationStat ).GetProperties();
    
    			var deserializedJsonClass = new DeserializedJsonClass
    			{
    				Evaluations = new EvaluationStat[jsonObject.Count / properties.Length]
    			};
    
    			for( var i = 1; i <= jsonObject.Count / properties.Length; i++ )
    			{
    				deserializedJsonClass.Evaluations[ i - 1 ] = new EvaluationStat();
    				foreach( var field in properties )
    				{
    					field.SetValue( deserializedJsonClass.Evaluations[ i - 1 ],
    					                jsonObject[ $"{field.Name}{i:000}" ].ToObject( field.PropertyType ) );
    				}
    			}
    			return deserializedJsonClass;
    		}
    
    		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
    		{
    			throw new NotImplementedException();
    		}
    	}
