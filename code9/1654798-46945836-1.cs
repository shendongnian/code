    string SeparateToWords(string pascalSencentce)
    {
        if(string.IsNullOrEmpty(pascalSencentce))
        {
            return pascalSencentce;
        }
        var sb = new StringBuilder();
        // note I'm starting from 1 not from 0 here
        for(var i = 1; i < pascalSencentce.Length; i++)
        {
            if(char.IsUpper(pascalSencentce[i]))
            {
                sb.Append(" ").Append(pascalSencentce[i].ToString().ToLower());
            }
            else
            {
                sb.Append(pascalSencentce[i]);
            }
        }
        sb.Insert(0, pascalSencentce[0]);
        return sb.ToString();
    }
