    var objTest = new TestPrimaryObject {
        param1 = "test1",
        param2 = "test2",
        param3 = "test3",
        param4 = "test4"
    };
    
    var path = "http://example.com?param2={0}&param4={1}";  
    //HttpUtility from System.Web;
    var keys = HttpUtility.ParseQueryString(new Uri(path).Query).AllKeys.Select(x => typeof(TestPrimaryObject).GetProperty(x).GetValue(objTest)).ToArray();
    var formatedString = string.Format(path, keys);
    //output - http://example.com?param2=test2&param4=test4
