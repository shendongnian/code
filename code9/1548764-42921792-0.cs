    var myClassList = new List<MyClass>();
    for (int i = 1; i <= ConfigurationManager.AppSettings.Count / 3; i++)
        {
         try
            {
              /* Prepare index keys to config */
              string tagNameConfigCode = "tag" + i + "_name";
              string tagAccessConfigCode = "tag" + i + "_access";
              string  tagDefaultValueConfigCode = "tag" + i + "_defaultValue";
              /* If they contain data, we'll create a class from them */
              if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[tagNameConfigCode ]) &&
                  !string.IsNullOrEmpty(ConfigurationManager.AppSettings[tagAccessConfigCode ]) &&
                  !string.IsNullOrEmpty(ConfigurationManager.AppSettings[tagDefaultValueConfigCode ]))
                  {
                      /* Preparing the values - easier to debug and read */
                      var tagNameValue = ConfigurationManager.AppSettings[tagNameConfigCode];
                      var tagAccessValue = ConfigurationManager.AppSettings[tagAccessConfigCode];
                      var tagDefaultValueValue = ConfigurationManager.AppSettings[tagDefaultValueConfigCode];
                      /* Creating the class for each trio of values */
                      var myClass = new MyClass()
                      {
                           tagName = tagNameValue,
                           tagAccess = tagAccessValue,
                           tagValue = tagDefaultValueValue 
                      };
                      /* Once done, adding to the list - here you'll have all your classes in one place */
                      myClassList.Add(myClass );
                  }
            }
            catch(Exception ex)
            {
                 logger.ExceptionMessage(ex.Message);
            }
     }
