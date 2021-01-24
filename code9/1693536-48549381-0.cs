    private static bool AttemptIdentify()
    {
        // waiting for either the user cancels or a finger is inserted
        lock (_syncFinger)
        {
            _syncIdentity = null;
            Thread tEscape = new Thread(new ThreadStart(HandleIdentifyEscape));
            Thread tIdentify = new Thread(new ThreadStart(HandleIdentify));
            tEscape.IsBackground = false;
            tIdentify.IsBackground = false;
            tEscape.Start();
            tIdentify.Start();
            Monitor.Wait(_syncFinger); // -> Wait part
        }
    
        // Checking the change in the locked object
    
        if (_syncIdentity != null) // checking for identity found
        {
            Console.WriteLine("Identity: {0}", ((FingerData)_syncIdentity).Guid.ToString());
            return true;
        }
    
        return false; // returns with no error
    }
    
    private static void HandleIdentifyEscape()
    {
        do
        {
            Console.Write("Enter 'c' to cancel: ");
        } while (Console.ReadKey().Key != ConsoleKey.C);
        LockNotify((object)_syncFinger);
    }
    
    private static void HandleIdentify()
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
    
        __syncIdentity = temp;
        LockNotify(_syncFinger);
    }
