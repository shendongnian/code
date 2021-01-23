    public CallerHanderOrMethod()
    {
        try{
            var img = farmerManager.getPhoto(farmerId);
        }
        catch(Exception ex) //consider throwing a more specific exception.
        {
            //load the default silhouette image into the picture box. 
        }
    }
