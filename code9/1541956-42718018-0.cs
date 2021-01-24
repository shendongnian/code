    public static class StringHelper
    {
        public static string RemoveExtraWhiteSpace(this string s)
        {
            int n = s.Length;
            StringBuilder sb = new StringBuilder(n); //to make output
            int nLineBreaks = 2; //number of repetitive line breaks, assume there were 2 enter chars before begining of s (to avoid adding initial line breaks or spaces)
            bool prevCharWasCrLf = false; //we can't use nEneter for this purpose as it skip white spaces between line breaks
            char ch1, ch = '\0'; //ch1 is prev char, ch is current char
            for (int i = 0; i < n; i++) //iterate through chars
            {
                ch1 = ch; ch = s[i]; //get next char
                if (ch == '\r' || ch == '\n')
                {
                    if (prevCharWasCrLf && ch != ch1) { prevCharWasCrLf = false; continue; } //this char is second of CrLf pair, ignore it as we already treat it
                    //if (prevCharWasCrLf == false || ch == ch1) /if we prefer don't use continue
                    prevCharWasCrLf = true;
                    nLineBreaks++;
                    if (nLineBreaks <= 2) //append new line break if we have less than 2 
                    {
                        if (sb.Length > 0 && sb[sb.Length - 1] == ' ') sb.Length--;  //remove prev space as it was before an enter
                        sb.Append("\r\n");
                    }
                }
                else
                {
                    if (ch == ' ' || ch == '\t')
                    {
                        if (nLineBreaks == 0 && ch1 != ' ' && ch1 != '\t') sb.Append(' '); //don't add more space after another space or enter
                    }
                    else
                    {
                        nLineBreaks = 0; sb.Append(ch); //its a normal char, add it to output
                    }
                    prevCharWasCrLf = false;
                }
            }
            return sb.ToString().TrimEnd('\r', '\n'); //if we don't use nReturn = 2 at begining, we shall run: .Trim('\r', '\n', ' ', '\t');
        }
    }
