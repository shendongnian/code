    public void Place(object info)
    {
           if(info is int){
               int result = (int)info;
               ...
                   
           }
           else if (info is string){
               string result = (string)info;
               ...
           }
    }
