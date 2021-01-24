    void Start()
    	{
    		CircleCollider2D getComponent = GetComponent<CircleCollider2D>();
    		CircleCollider2D empty = null;
			CircleCollider2D newCC = new CircleCollider2D();
    		Debug.LogFormat("getComponent.GetInstanceID() {0}", getComponent.GetInstanceID());
    		Debug.LogFormat("newCC.GetInstanceID() {0}", newCC.GetInstanceID());
    		try
    		{
    			Debug.LogFormat("empty.GetInstanceID() {0}", empty.GetInstanceID());
    		}
    		catch (System.NullReferenceException e)
    		{
    			Debug.Log("empty.GetInstanceID() doesnt work, im true null");
    		}
    		try
    		{
    			string t = getComponent.name;
    		}
    		catch (System.Exception e)
    		{
    			Debug.Log(string.Format("getComponent fires {0} when any field is null", 
					e.ToString()));
    		}
    		try
    		{
    			string t = newCC.name;
    		}
    		catch (System.Exception e)
    		{
    			Debug.Log(string.Format("newCC fires {0} when any field is null",
					e.ToString()));
    		}
    	}
