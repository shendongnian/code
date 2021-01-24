    public static JsonPatchDocument CreatePatch(object originalObject, object modifiedObject)
    {
    	var original = JObject.FromObject(originalObject);
    	var modified = JObject.FromObject(modifiedObject);
    
    	var patch = new JsonPatchDocument();
    	FillPatchForObject(original, modified, patch);
    
    	return patch;
    }
    
    static void FillPatchForObject(JObject orig, JObject mod, JsonPatchDocument patch)
    {
    	var origNames = orig.Properties().Select(x => x.Name).ToArray();
    	var modNames = mod.Properties().Select(x => x.Name).ToArray();
    
    	// Names removed in modified
    	foreach (var k in origNames.Except(modNames))
    	{
    		var prop = orig.Property(k);
    		patch.Remove(prop.Path);
    	}
    
    	// Names added in modified
    	foreach (var k in modNames.Except(origNames))
    	{
    		var prop = mod.Property(k);
    		patch.Add(prop.Path, prop.Value);
    	}
    
    	// Present in both
    	foreach (var k in origNames.Intersect(modNames))
    	{
    		var origProp = orig.Property(k);
    		var modProp = mod.Property(k);
    		var path = origProp.Path;
    
    		if (origProp.Value.Type != modProp.Value.Type)
    		{
    			patch.Replace(path, modProp.Value);
    		}
    		else if (!string.Equals(
    						origProp.Value.ToString(Newtonsoft.Json.Formatting.None),
    		  				modProp.Value.ToString(Newtonsoft.Json.Formatting.None)))
    		{
    			if (origProp.Value.Type == JTokenType.Object)
    			{
    				// Recurse into objects
    				FillPatchForObject(origProp.Value as JObject, modProp.Value as JObject, patch);
    			}
    			else
    			{
    				// Replace values directly
    				patch.Replace(path, modProp.Value);
    			}
    		}		
    	}
    }
