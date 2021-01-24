        using System.Text.RegularExpressions;
        
        public void Main()
		{
            
            string strFilename = Dts.Variables["filename"].Value.ToString();
            string strNumber;
            MatchCollection mc = Regex.Matches(strFilename, @"(?:_)\K[0-9][0-9][0-9][0-9][0-9](?=_)");
            //The last match contains the value needed
            strNumber = mc[mc.Count - 1].Value;
            Dts.Variables["FileNumber"].Value.ToString();
            Dts.TaskResult = (int)ScriptResults.Success;
		}
