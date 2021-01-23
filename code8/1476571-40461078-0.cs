    Functions funcs = new Functions();
    funcs.errEmailV2(someVariableThatisAString, someIntVariable);
    public void errEmailV2(params object[] paths)
    {
        string strVars="";
        //a rather simplified version of the loop:
        for (int i = 0; i < paths.Length; i++)
        {
            strVars+= paths[i].ToString();
        }
        sendEmail("me@email","emailSubject",strVars);  
    }
