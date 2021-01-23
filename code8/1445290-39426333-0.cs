            int count = typeof(T).GetProperties().Count();
            for ( int y = 0 ; y < theList.Count ; y++ )
            {  
                for ( int x = 0; x < count; x++ )
                {
                    var propertyName = typeof(T).GetProperties()[x].Name;
                    var propertyValue = typeof(T).GetProperties()[x].GetValue( theList[y] , null );
                    var propertyType = typeof(T).GetProperties()[x].PropertyType;
                    Console.WriteLine(propertyType + " " + propertyName +  " " + propertyValue );
                }                 
            }
        }
