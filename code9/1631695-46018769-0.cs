    const int attemptsNum = 10;
    for (int attempt = 0; attempt < attemptsNum; attempt++)
    {
        try
        {
            File.Delete(path);
        }
        catch
        {
            if (attempt == attemptsNum - 1)
            {
                throw;
            }
            else
            {
                await Task.Delay(500);
            }
        }
    }
