    public class CustomColumns : Cols
    {
    	public int CustomColA { 
    		get{
    			return this.ColA + 10;
    		}
    	}
    	public int CustomColB { 
    		get{
    			return this.ColB + 30;
    		}
    	}
    	public int CustomColC { 
    		get{
    			return this.ColC + 50;
    		}
    	}
    	public CustomColumns(Cols cols)
    	{
    		string[] localNames = this.GetType().GetMembers().Where(m => m.MemberType.ToString() == "Property").Select(m => m.Name).ToArray();
    		string[] ctorNames = cols.GetType().GetMembers().Where(m => m.MemberType.ToString() == "Property").Select(m => m.Name).ToArray();
    		string[] names = localNames.Intersect(ctorNames).ToArray();
    		foreach (string s in names)
    		{
    			PropertyInfo propSet = this.GetType().GetProperty(s);
    			PropertyInfo propGet = typeof(Cols).GetProperty(s);
    			propSet.SetValue(this, propGet.GetValue(cols, null));
    		}
    	}
    }
