    private static bool AttemptIdentify()
    {
        Task<WinBioIdentity> fingerTask = Task.Run(HandleIdentify);
        Task cancelTask = Task.Run(HandleIdentifyEscape);
        if (Task.WaitAny(fingerTask, cancelTask) == 0)
        {
            Console.WriteLine("Identity: {0}", fingerTask.Result.Guid);
            return true;
        }
        return false;
    }
    
    private static void HandleIdentifyEscape()
    {
        do
        {
            Console.Write("Enter 'c' to cancel: ");
        } while (Console.ReadKey().Key != ConsoleKey.C);
    }
    
    private static WinBioIdentity HandleIdentify()
    {
        WinBioIdentity temp = null;
        do
        {
            Console.WriteLine("Enter your finger.");
            try // trying to indentify
            {
                temp = Fingerprint.Identify(); // returns FingerData type
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            // if couldn't identify, temp would stay null
            if(temp == null)
            {
                Console.Write("Invalid, ");
            }
        } while (temp == null);
    
        return temp;
    }
