    public async Task<string> sendrequest(int index)
    {
        string result = string.Empty;
        try
        {
            result = index.ToString() + await this.getresult();
        }
        catch (Exception ex)
        {
            System.IO.File.AppendAllText("D:\\WebService\\FelixTest\\log.txt",ex.ToString());
        }
        return result;
    }
