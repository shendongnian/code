    private List<int> acceptableChars = new List<int>();
        private void createListOfAcceptableCharacters()
        {
            
            List<int> acceptableChars = new List<int>();
            acceptableChars.Add(45);// -
            acceptableChars.Add(46);// .
            acceptableChars.Add(47);// /
            for (int a = 97; a < 123; a++)
            {// a through z
                acceptableChars.Add(a);
            }
            for (int a = 48; a < 58; a++)
            {//0 through 9
                acceptableChars.Add(a);
            }
        } 
        public string parseURL(string input)
        {//you would only do this once in reality
            createListOfAcceptableCharacters();
            //basic cleanup
            input = input.ToLower();
            //Regex.Replace would be more elegant here but string.replace works, too
            input = input.Replace(".cm", ".com").Replace("htpp","http").Replace("htp", "http").Replace("http.", "http:").Replace("//ww.", "//www.").Replace(":/", "://").Replace(":////", "://").Replace(":///", "://").Replace(" ","");
            //check to see if URL is generally valid as-is
            bool isValid = isValidURL(input); 
            if (isValid)
            {
                return input;
            }
            //try to salvage a poorly formed URL
            bool isSecure = input.Substring(0, 5).IndexOf("https") > -1 ? true : false;
            input = input.Replace(" ","").Replace(":","").Replace("https","").Replace("http//", "").Replace("http/", "").Replace("http", "").Replace("http", "").Replace("//","").Replace("www","").Replace("ww","").Replace("cm","com");//again, regex.replace would be more elegant
            //clear front end to first period if it exists before space 6
            if (input.IndexOf(".") < 7)
            {
                int period = input.IndexOf(".");
                input = input.Substring(period+1);
            }
            //get the extension
            string extension = "";
            if (input.Substring(input.Length - 1) == "/")
            {
                input = input.Substring(0, input.Length - 1);
            }
            if (input.Substring(input.Length - 4, 1) == ".")
            {
                //extension is where we expect
                extension = input.Substring(input.Length - 3, 3);
                input = input.Replace("." + extension, "");
            }else
            {
                //cannot find extension - can't process
                return "badURL";
            }
            string url = "";
            //move backwars through path, collecting only acceptable characters (note, this can be done with REGEX as well)
            for (int i = input.Length-1; i > -1; i--)
            {
                string thisChar = input.Substring(i, 1);
                if (thisChar == ":")
                {
                    return "http://" + url + "." + extension;
                }
                int utf = (int)Convert.ToChar(thisChar);
                
                //compare current char to list of acceptable chars
                if (acceptableChars.Contains(utf))
                {
                    url = thisChar+url;
                }
            }
            //final cleanup and full path formation
            if (url.Substring(0, 1) == ".")
            {
                url = url.Substring(1);
            }
            url = isSecure ? "https://" : "http://" + url + "." + extension;
            //optional
            url = isSecure ? "https://www." : "http://www." + url + "." + extension;
            url = url.Replace("::", ":");
            //test salvaged url. If reasonable, return else return badURL
           if (isValidURL(url))
            {
                return url;
            }else
            {
                return "badURL";
            }
        }
        
        private bool isValidURL(string url)
        {
            bool isValid = Regex.IsMatch(url, @"^((http[s]?:[/][/])?(\w+[\-.])+com|((http[s]?:[/][/])?(\w+[\-.])+com[/]|[.][/])?\w+([/]\w+)*([/]|[.]html|[.]php|[.]gif|[.]jpg|[.]png)?)$");
            return isValid;
        }
