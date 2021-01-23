       string yourLogText = "you log text";
       string[] lines = yourLogText.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
       string builtErrorText = "";
       Boolean isBuildingError = false;
       List<String> resultingErrors = new List<string>();
       for (int i = 0; i < lines.Length; i++)
       {
           if (lines[i].StartsWith("ERROR:"))
            {
              isBuildingError = true;
             if (!String.IsNullOrEmpty(builtErrorText))
                   resultingErrors.Add(builtErrorText);
              builtErrorText = lines[i];
           }
           else if (lines[i].StartsWith("NOTE:") || lines[i].StartsWith("WARNING:"))
           {
                isBuildingError = false;
                if (!String.IsNullOrEmpty(builtErrorText))
                     resultingErrors.Add(builtErrorText);
           }
           else if (isBuildingError)
           {
               // If you want them to appear on different lines.
               builtErrorText += Environment.NewLine + lines[i];
            }
          }
        }
        // In case it ends with an error
        if (String.IsNullOrEmpty(builtErrorText))
            resultingErrors.Add(builtErrorText);
