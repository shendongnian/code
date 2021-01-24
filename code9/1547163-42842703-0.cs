    private async static Task<bool> SFTPFileGetHelper()
    {
        try
        {
            Task<String> task1 = GetFileAsync(sftpFile1, localFile1);
            Task<String> task2 = GetFileAsync(sftpFile2, localFile2);
            await Task.WhenAll(task1, task2);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
