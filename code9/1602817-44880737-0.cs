    var userPermissions =
	    groupPermissions
            .SelectMany(pv => pv.Value) //Select all the Dictionaries
            .GroupBy(pv => pv.Key) //Get each permission into its own group
            .ToDictionary(g => g.Key, //Create the result
                g => g.Any(permission => permission.Value));
