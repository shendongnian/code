    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    Dictionary<string, object> resourceDictionary = typeof(Properties.Resources)
			.GetProperties
                (
                    BindingFlags.Static
                  | BindingFlags.Public
                )
			.ToDictionary
                (
                    p => p.Name, 
                    p => p.GetValue(null) 
                );
