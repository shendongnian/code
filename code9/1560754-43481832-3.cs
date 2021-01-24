    MatchCollection MC = Regex.Matches(txtFromUser.Text, @"\(\?\<(?<MyGroupName>\w+)\>(?<MyExpression>((?<BR>\()|(?<-BR>\))|[^()]*)+)\)");
    foreach (Match M in MC)
    {
        string sGroupName = M.Groups["MyGroupName"].Value;
        string sSubExpression = M.Groups["MyExpression"].Value;
        //Do what I need to do with the sub-expression
        MessageBox.Show(sGroupName + ":" + sSubExpression);
    }
