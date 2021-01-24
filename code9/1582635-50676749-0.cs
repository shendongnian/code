    public ImageSource Avatar
    {
        get  
        {
          return ImageSource.FromStream(()=> 
            {
              return new MemoryStream(this.User.Avatar);
            });
         }
    }
