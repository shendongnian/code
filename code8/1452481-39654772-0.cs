       List<A> yourData = new List<A>();
    
            System.Reflection.PropertyInfo[] properties = typeof(A).GetProperties()
                .Where(x => x.PropertyType == typeof(double))         //do a sanity check if property is double
                .ToArray();
    
    
            //the user has to choose which PropertyInfo has to be taken... make a combobox or similar and use properties as binding source
            var propertyX = properties[3];
            var propertyY = properties[4];
    
            // create a list with the values
            List<Point> points = new List<Point>();
            foreach (A item in yourData)
            {
                Point newPoint = new Point();
    
                newPoint.X =(double) propertyX.GetValue(item); 
                newPoint.Y = (double)propertyY.GetValue(item);
                points.Add(newPoint);
            }
    
            //now do something with you extracted data and have fun
