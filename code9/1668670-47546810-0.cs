    public void DoAllTypes()
    {
    	foreach (var type in Types)
    	{
    		DoSmth(type);
    	}
    }
    
    private void DoSmth(Type t)
    {
        switch (this.value) {
            case X xval:
                //Handle type X
                break;
            case Y xval:
                //Handle type Y
                break;
            //And so on...
        }
    }
