    <ul>
      <%#GenerateLIs(Eval<string>("Foobar"))%>
    </ul>
    
    <script runat="server">
    public string GenerateLIs(string foobarValue)
    {
       
    string liList = string.Empty;
    string[] foobarSplit = "foobar".Split('|');
        foreach (string item in foobarSplit)
            liList += "<li>" + item + "</li>";
    
    return liList;
    }
    </script>
