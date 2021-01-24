    Task.Run(() =>
    {
        const int attemptsNum = 10;
        for (int attempt = 0; attempt < attemptsNum; attempt++)
        {
            try
            {
                File.Delete(path);
                break;
            }
            catch
            {
                if (attempt == attemptsNum - 1)
                {
                    throw; // or log exception here
                }
                else
                {
                    await Task.Delay(500);
                }
            }
        }
    });
