    private string RemoveTab(string text)
    {
        string tempText = String.Empty;
    
        // An Action is an object that encapsulates a method that does
        // not return a value. If you need to return something, use a Func<>.
        // Create an Action<> that will be used in the loop until the initial
        // condition has ceased.  This Action<> will replace itself with the
        // subsequent Action<>.
        Action<char> Process = new Action<char>(c =>
        {
            if ((c != ' ') && (c != '\t'))
            {
                tempText += c;
                // Replace the Action with new functionality for subsequent
                // iterations of the loop.
                Process = new Action<char>(c1 =>
                {
                    if (c1 != '\t')
                    {
                        tempText += c1;
                    }
                });
            }
        });
        // Now the loop will use the Process Action<>, which will change
        // itself to new behaviour once the initial condition no longer holds.
        foreach (char c in text)
        {
            Process(c);
        }
        return tempText;
    }
