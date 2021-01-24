    for (int i = 1; i <= ConfigurationManager.AppSettings.Count / 3; i++)
        {
         try
            {
              string tag_name = "tag" + i + "_name";
              string tag_access = "tag" + i + "_access";
              string tag_defaultValue = "tag" + i + "_defaultValue";
              if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[tag_name]) &&
                  !string.IsNullOrEmpty(ConfigurationManager.AppSettings[tag_access]) &&
                  !string.IsNullOrEmpty(ConfigurationManager.AppSettings[tag_defaultValue]))
                  {
                    //THERE DYNAMICALLY CREATED OBJECTS AND PROPERTIES ARE
                    var MyClass = new ExpandoObject() as IDictionary<string, Object>;
                    MyClass.Add("tag1_name", ConfigurationManager.AppSettings[tag_name].ToString());
                    MyClass.Add("tag1_access", ConfigurationManager.AppSettings[tag_access].ToString());
                    MyClass.Add("tag1_defaultValue", ConfigurationManager.AppSettings[tag_defaultValue].ToString());
                    //USING PROPERTIES IN SAMPLE CODE
                    object tag1Name = MyClass.tag1_name;
                    object tag1Access = MyClass.tag1_access;
                    object tag1DefaultValue = MyClass.tag1_defaultValue;
                    ++tag_count;
                  }
            }
            catch(Exception ex)
            {
                 logger.ExceptionMessage(ex.Message);
            }
     }
