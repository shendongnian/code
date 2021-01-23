    public DBController()
        {
            HttpCookie StudentCookies = new HttpCookie("StudentCookies");
            StudentCookies.Value = "hallo";
            StudentCookies.Expires = DateTime.Now.AddHours(1);
            Response.SetCookie(StudentCookies);
            Response.Flush();
        }
