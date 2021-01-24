    string line = "username=user321@user.com&password=somepassword&grant_type=password";
    var parameters = System.Web.HttpUtility.ParseQueryString(line);
    parameters.Set("password", new string('*', parameters["password"].Length));
    // Or if you want a fixed amount of asterisks:
    // parameters.Set("password", "********");
    string fixedLine = parameters.ToString();
    Console.WriteLine(line);
    Console.WriteLine(System.Web.HttpUtility.UrlDecode(fixedLine));
