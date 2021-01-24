    [Test]
    public void Index_HasParamWithBinderAttribute()
    {
      var targetType = typeof(DefaultController);
      var targetAction = targetType.GetMethod("Index", BindingFlags.Instance | BindingFlags.Public); // if there is an exception below, someone removed action from the controller
    
      var targetParams = targetAction.GetParameters().FirstOrDefault(x => x.Name == "MyId"); // if there is an exception below, then someone renamed the action argument
    
      Assert.That(targetParams.ParameterType, Is.EqualTo(typeof(int?))); // if this fails, then someone changed the type of parameter
      Assert.That((targetParams.GetCustomAttributes(true).FirstOrDefault() as ModelBinderAttribute).BinderType, Is.EqualTo(typeof(MyBinder))); // if this fails, then either there is no more a modelbinder or the type is wrong
    }
