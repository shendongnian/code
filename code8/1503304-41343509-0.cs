    public static class Extensions
    {
    	public static void Add(this string object_model, Img img)
    	{
    		switch (object_model)
    		{
    			case "UserImage":
    				{ UserImage.Add(img); break; }
    			case "CarImage":
    				{ CarImage.Add(img); break; }
    		}
    	}
    }
