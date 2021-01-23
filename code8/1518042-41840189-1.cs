        enum State {
            Initial,
            Connecting,
            ..
        }
        string line = string.Empty;
        State state = State.Initial;
        while ((line = process.StandardOutput.ReadLine()) != null)
        {
            Console.WriteLine("CLI Says: " + line);
            if(line == string.Empty) continue; // skip blank lines
            if(line.StartsWith("VPN>")
            {
                switch(state) 
                { 
                   case State.Initial: 
                       SendConnect(); 
                       state = State.Connecting;
                       break;
                   ..
                }
            }
            else // check what is being printed by vpn is correct, no errors, etc.
        }
