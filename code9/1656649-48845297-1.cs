    var privateKeyContent = System.IO.File.ReadAllText(authKeyPath);
    var privateKeyList = privateKeyContent.Split('\n');
    int upperIndex = privateKeyList.Length;
    StringBuilder sb = new StringBuilder();
    for(int i= 1; i< upperIndex - 1; i++ )
    {
        sb.Append(privateKeyList[i]);
        Debug.WriteLine(privateKeyList[i]);
    }
