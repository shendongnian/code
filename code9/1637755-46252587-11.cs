        foreach (var callVariables in doc.Descendants(pubsub + "callvariables"))
        {
            // Note use of Elements, not Descendants. You still need
            // the namespace part though...
            foreach (var callVariable in callVariables.Elements(pubsub + "CallVariable"))
            {
                // Do what you want
            }
        }
