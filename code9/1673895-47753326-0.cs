    string cookieValue = Guid.NewGuid().ToString();
    //Creating a cookie which has the name "UserId"
    HttpCookie userIdCookie = new HttpCookie("userId");
    userIdCookie.Value = cookieValue;
    //This is where you would state how long you would want the cookie on the client. In your instance 2 days later.
    userIdCookie.Expires = DateTime.Now.AddDays(3);
    Response.SetCookie(userIdCookie);
