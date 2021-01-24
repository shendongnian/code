    string sessionVar = "";
    if(condition){
    ...
    sessionVar = table.Rows[0]["personID"].ToString();
    ...
    }
    //Use the variable after the 'if' statement.
    var newString =  sessionVar;
