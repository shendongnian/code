    sqlCommand.CommandText = "SELECT ... WHERE ";
    string whereBits = userInput.Split(" ");
    var parameters as new Dictionary<string, string>();
    parameters["customercity"] = "c.City";
    parameters["vehiclenumber"] = "v.Number";
    foreach(var token in whereBits){
        var frags = token.Split(':');
        string friendlyName = frags[0].ToLower();
        //handle here the AND and OR -> append to sql command text and continue the loop        
        if(parameters.ContainsKey(friendlyName)){
          sqlCommand.CommandText += parameters[friendlyName] + " = @" + friendlyName;
          sqlCommand.Parameters.AddWithValue("@" + friendlyname, frags[1]);
        }
    }
    //now you should have an sql that looks like
    //SELECT ... WHERE customercity = @customercity ...
    // and a params collection that looks like:
    //sql.Params[0] => ("@customercity", "Seattle", varchar)...
