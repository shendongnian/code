    // Some cookie
    var cookie = new HttpCookie("LoginCookie") { Value = "Hello!" };
            
    // Accessing its value
    var cookieValue = cookie.Value;
    // Some label
    var label = new Label();
    
    // Setting the label text
    label.Text = cookieValue;
