    private string OMathAutoCorrect(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            Globals.ThisAddIn.Application.OMathAutoCorrect.UseOutsideOMath = true;
            var retString = input;
            foreach (OMathAutoCorrectEntry ac in Globals.ThisAddIn.Application.OMathAutoCorrect.Entries)
            {
                if (retString.Contains(ac.Name))
                {
                    var matchIndex = retString.IndexOf(ac.Name);
                    var sb = new StringBuilder();
                    //Capture all data prior to the match:
                    sb.Append(retString.Substring(0, matchIndex));
                    //Add the Match
                    sb.Append(ac.Value);
                    //Capture all data after the match:
                    var indexAfterMatch = matchIndex + ac.Name.Length;
                    var remLength = retString.Length - indexAfterMatch;
                    sb.Append(retString.Substring(indexAfterMatch, remLength));
                    retString = sb.ToString();
                }
                Debug.WriteLine($"{ac.Name}, {ac.Value}, Char#: {ac.Value.Length}");
            }
            Globals.ThisAddIn.Application.OMathAutoCorrect.UseOutsideOMath = false;
            return retString;
        }
