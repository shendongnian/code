    private HttpCookie CreateStudentCookie()
    {
        HttpCookie StudentCookies = new HttpCookie("StudentCookies");
        StudentCookies.Value = "hallo";
        StudentCookies.Expires = DateTime.Now.AddHours(1);
        return StudentCookies;
    }
    //some action method
    Response.Cookies.Add(CreateStudentCookie());
