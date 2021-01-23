    static int _MaxPath = 0;
    public static void GetLongestFilePath(string p)
    {
        try
        {
            foreach (string d in Directory.GetDirectories(p))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    if (f.Length > _MaxPath)
                    {
                        _MaxPath = f.Length;
                    }
                }
                GetLongestFilePath(d);
            }
        }
        catch (PathTooLongException e)
        {
            _MaxPath = -2;
        }
        catch (Exception e)
        {
            _MaxPath = -1;
        }
        finally
        {
            System.Environment.Exit(-99);
        }
    }
