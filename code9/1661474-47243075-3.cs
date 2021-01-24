    foreach(var propertyName in listOfString){
    // This line of code retrives the value of the propety in the user class
     var retrivedValue = userType.GetProperty(propertyName).GetValue(user);
    // This line of code sets the value retrived to the property in the newUser class
     userType.GetProperty(propertyName).SetValue(newUser, retrivedValue , null);
    }
