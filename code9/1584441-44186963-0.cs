    List<string> outFiles = new List<string>(Directory.GetFiles(workingDir));
    bool noSort;
    do
    {
        noSort = true;
        for (int i = 0; i <= outFiles.Count - 2; i++)
        {
            if (outFiles[i].EndsWith("IAT.TXT"))
            {
                if (!outFiles[i + 1].EndsWith("IAT.TXT"))
                {
                    string temp = outFiles[i + 1];
                    outFiles[i + 1] = outFiles[i];
                    outFiles[i] = temp;
                    noSort = false;
                }
            }
        }
    }
    while (noSort == false);
