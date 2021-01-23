    public class KeysJsonConverter<T> : JsonConverter {
       private readonly Type[] _types;
    
       public KeysJsonConverter(params Type[] types) {
          _types = types;
       }
    
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
          JToken t = JToken.FromObject( value );
    
          if( t.Type != JTokenType.Object ) {
             t.WriteTo( writer );
          }
          else {
             JObject o = ( JObject ) t;
             IList<JProperty> jProperties = o.Properties().ToList();
    
             PropertyInfo[] viewModelProperties = typeof( T ).GetProperties();
             foreach( var thisVmProperty in viewModelProperties ) {
                object[] thisVmPropertyAttributes = thisVmProperty.GetCustomAttributes( true );
                var jObjectForVmProperty = new JObject();
                var thisProperty = jProperties.Single( x => x.Name == thisVmProperty.Name );
                jObjectForVmProperty.Add( "ActualValue", thisProperty.Value );
                foreach( var thisVmPropertyAttribute in thisVmPropertyAttributes ) {
    
                   if (thisVmPropertyAttribute is MaxLengthAttribute ) {
                         CreateObjectForProperty( thisVmPropertyAttribute as MaxLengthAttribute,
                            jObjectForVmProperty );
                   }
                   else if (thisVmPropertyAttribute is RequiredAttribute ) {
                         CreateObjectForProperty( thisVmPropertyAttribute as RequiredAttribute,
                            jObjectForVmProperty );
                   }
                   else if (thisVmPropertyAttribute is DisplayAttribute ) {
                         CreateObjectForProperty( thisVmPropertyAttribute as DisplayAttribute,
                            jObjectForVmProperty );
                   }
                   else {
                      continue; // Put more else if conditions like above if you want other types
                   }     
                }
    
                thisProperty.Value = jObjectForVmProperty;
             }
    
             o.WriteTo( writer );
          }
       }
    
       private void CreateObjectForProperty<TAttribute>(TAttribute attribute, JObject jObjectForVmProperty) 
             where TAttribute : Attribute
       {
          var jObjectForAttriubte = new JObject();
    
          var max = attribute as TAttribute;
          var maxPropeties = typeof( TAttribute ).GetProperties();
          foreach( var thisProp in maxPropeties ) {
             try {
    
                jObjectForAttriubte.Add( new JProperty( thisProp.Name, thisProp.GetValue( max ) ) );
             }
             catch( Exception ex) {
                // No need to worry. Fails on complex attribute properties and some other property types. You do not need this.
                // If you do, then you need to take care of it.
             }
          }
          jObjectForVmProperty.Add( typeof( TAttribute ).Name, jObjectForAttriubte );
       }
    
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
          throw new NotImplementedException( "Unnecessary because CanRead is false. The type will skip the converter." );
       }
    
       public override bool CanRead
       {
          get { return false; }
       }
    
       public override bool CanConvert(Type objectType) {
          return _types.Any( t => t == objectType );
       }
    }
