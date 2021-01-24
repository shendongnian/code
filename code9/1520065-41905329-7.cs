    var resources = new ResourceManager("CommonValues", myAssembly);
    //Example for use with enum
    SubscriptionType code = SubscriptionType.OneWeek;
    var display = resources.GetString("SubscriptionType." + code.ToString()); //Resource ID = "SubscriptionType.OneWeek";
    //Example for use with string constant
    var colorCode = CommonValues.Colors.Red;
    var display = resources.GetString("Colors." + colorCode); //Resource ID = "Colors.Red";
   
