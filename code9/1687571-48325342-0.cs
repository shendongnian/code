    public static void Main(string[] args)
    {
        var myOjects = new List<Test>();
        int startIndex = 1;
        while(true)
        {
            Test obj=new Test();
            obj.number=startIndex;
            myObjects.Add(obj);
            startIndex = startIndex + 1;
            if (startIndex > 5) break;
        }           
    }
