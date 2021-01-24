    class Person
    {
        //other fields...
    
        public string DeptName
        {
            get
            {
                if(myStaticMap==null || !myStaticMap.Contains(this.Id))
                {
                    //initialize your static map or throw exception
                }
                else
                {
                    return myStaticMap[this.Id];
                }
            }
        }
    }
