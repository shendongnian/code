    List<string> qsParams = new List<string>();
    string[] paramNames = new string[] { "k", "l", "o", "s", "t", "h", "exp" };
    for (int i = 0; i < additionalParameters.Length; i++)
    {
        if (!string.IsNullOrEmpty(additionalParameters[i]))
        {
            qsParams.Add(string.Format("{0}={1}", paramNames[i], additionalParameters[i]));
        }
    }
