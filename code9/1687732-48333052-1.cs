    //Some special attribute 
    [AttributeUsage(AttributeTargets.Field)]
    public class ShareFieldAttribute : Attribute {
    	
    }
    
    class Foo {
    
    	public class Physics {
    		float gravity = 9.8f;
    		float seperateDistance = 10f;
    	}
    	
    	//mark ShareField attribute to this field
    	[ShareField]
    	public Physics physics;
    
    	void Start(){
    	  
    		physics = new Physics();
    		Bar baz = AddComponent<Bar>(); 
    	}
    
    }
    
    class Bar {
    	void Start() {
    		//Get the field 'public Physics physics' by name and Type
    		Physics physics = GetShareField<Physics>("physics", null);
    		float gravity = physics ? physics.gravity : 3;
    		//...
    	}
    	
    	//Method Helper
    	public T GetShareField<T>(string fieldName, T defaultValue)
    	{
    		foreach(var c in GetComponents<MonoBehaviour>())
    		{
    			var fields = c.GetType().GetFields().Where(field => field.FieldType == T && field.Name == fieldName && field.IsDefined(typeof(ShareFieldAttribute), false));
    			return (T)fields[0].GetValue(c);
    		}
    		
    		return defaultValue;
    	}
    }
