            int highestNumber = 0;		
		
            PropertyInfo[] info = this.GetType().GetProperties(); 
            foreach(PropertyInfo propInfo in info)
            {
                if (propInfo.PropertyType == typeof(int))
				{
					int propValue = (int)(propInfo.GetValue(this, null));
					if (propValue > highestNumber) {
						highestNumber = propValue;
					}
				}
            }
            
            return highestNumber;
