    @{ 
        var username = "";
        var password = "";
        var confirmPassword = "";
        var regMsg = "";
        var minPass = 2;
        var maxPass = 5;
      
    
        if (!IsPost) {
        if (WebSecurity.IsAuthenticated) {
            regMsg = String.Format("You are already logged in. (User name: {0})", WebSecurity.CurrentUserName);
            }
        }
       
        if (IsPost){
        WebSecurity.Logout();    
        username = Request["username"];
        password = Request["password"];
        confirmPassword = Request["confirmPassword"];
    
        try {
            var mail = new System.Net.Mail.MailAddress(username);
        } catch {
            regMsg += "Invalid email format.";
        }
    
        //Validation.Add("username", Validator.Regex(@"^[A-Za-z0-9._%+-]+@@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", regMsg += "Invalid email format."));
        if (password != confirmPassword) {regMsg += "</br>Passwords don't match.";}
        if (WebSecurity.UserExists(username)) {regMsg += String.Format("</br>User '{0}' already exists.", username);}
        if (password.Length < minPass || password.Length > maxPass) {regMsg += "</br>Password doesn't meet length requirement.";}
        if (regMsg == "") {
            WebSecurity.CreateUserAndAccount(username,password,null,false);
            regMsg = String.Format("{0} created.", username);
            Response.Write("Registration Successful!");
            Response.Redirect("~/Default.cshtml");
            }
        }
    }
    
    <style>header {visibility: hidden;}</style>
    <body>
        <div>
            <h1>Register</h1>
            <form method="post">
                <p>
                    @if(regMsg != ""){
                        <span class="errorMessage">@Html.Raw(regMsg)</span>
                    }
                </p>
     
                <p>
                    <label for="username">Email Address:</label><br/>
                    <input type="text" name="username" id="username" value='@Request["username"]' />
                </p>
                <p>
                    <label for="password">Password @minPass-@maxPass Characters:</label><br/>
                    <input type="password" name="password" id="password" value="" />
                </p>   
                <p>
                    <label for="confirmPassword">Confirm Password:</label><br/>
                    <input type="password" name="confirmPassword" id="confirmPassword" value="" />
                </p>
                <p>
                    <input type="submit" value="Submit" />
                    <input type="button" value="Cancel" onclick="javascript:location.href='Default.cshtml'" />
                </p>   
                <p>
                </p>
            </form>
        </div>
    </body>
