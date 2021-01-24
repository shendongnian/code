    FB.API("/me/picture?redirect=false", HttpMethod.GET, ProfilePhotoCallback);
    
    private void ProfilePhotoCallback (IGraphResult result)
    	{
    		if (string.IsNullOrEmpty(result.Error) && !result.Cancelled) {
    			IDictionary data = result.ResultDictionary["data"] as IDictionary;
    			string photoURL = data["url"] as string;
    
    			StartCoroutine(fetchProfilePic(photoURL));
    		}
    	}
    
    	private IEnumerator fetchProfilePic (string url) {
    		WWW www = new WWW(url);
    		yield return www;
    		this.profilePic = www.texture;
    
    		//Construct a new Sprite
    		Sprite sprites = new Sprite();     
    
    		//Create a new sprite using the Texture2D from the url. 
    		//Note that the 400 parameter is the width and height. 
    		//Adjust accordingly
    
    		sprite = Sprite.Create(www.texture, new Rect(0, 0, 50 ,50), Vector2.zero);  
    		sprites = Sprite.Create(www.texture, new Rect(0, 0, 50 ,50), Vector2.zero);  
    	
    	}
