    <p>There are 
    @{
        var objects = new List<string> { "cars", "dogs", "computers", "houses" };
        string myObjs = "";
        for (var i = 0; i < objects.Count; ++i)
        {
            if (objects.Count > 1 && i == objects.Count - 1)
            {
                myObjs += " and";
            }
            else if (i > 0)
            {
                myObjs += ",";
            }
            myObjs += " " + objects[i];
        }
    }
    @myObjs.Trim()!</p>
