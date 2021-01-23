			List<ConfigurationObjectBase> tmplist = ObjectRegistry.Where(o =>   
              (o.GetType().GetProperties(System.Reflection.BindingFlags.Public | 
                                       System.Reflection.BindingFlags.NonPublic | 
               System.Reflection.BindingFlags.Instance).Where(
				prop => Attribute.IsDefined(prop, typeof(PropertyCanHaveReference)))).Any()).ToList();
