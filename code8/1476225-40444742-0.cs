 		public static string ApplyFormattingTo(this object myObject, string propertyName) 
		{
		    var property = myObject.GetType().GetProperty(propertyName);		
			var attriCheck = property.GetCustomAttributes(typeof(DisplayFormatAttribute), false); 
			if(attriCheck.Any())
			{	
			     return string.Format(((DisplayFormatAttribute)attriCheck.First()).DataFormatString,property.GetValue(myObject, null));	
			}
			return "";
		}
