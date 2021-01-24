        void SetPropertyValueByPath(object obj, string path, object newvalue)
        {
            var pathSegments = /* split path on '.' */;
            
            if (pathSegments.Length == 1)
            {
                SetPropertyValue(obj, pathSegments[0], newValue); 
            }
            else
            {
                //  If more than one remaining segment, recurse
                
                var child = GetNamedPropertyvalue(obj, pathSegments[0]);
        
                return SetPropertyValueByPath(obj, String.Join(".", pathSegments.Skip(1)), newValue);
            }
        }
