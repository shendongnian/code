    internal virtual bool IsEnabled()
    {
    	UnityEngine.Object[] targets = this.targets;
    	for (int i = 0; i < targets.Length; i++)
    	{
    		UnityEngine.Object @object = targets[i];
    		if ((@object.hideFlags & HideFlags.NotEditable) != HideFlags.None)
    		{
    			return false;
    		}
    		if (EditorUtility.IsPersistent(@object) && !AssetDatabase.IsOpenForEdit(@object))
    		{
    			return false;
    		}
    	}
    	return true;
    }
