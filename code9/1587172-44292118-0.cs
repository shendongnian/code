    static void FindInvalidAttributes(Dictionary<string, List<string>> dictionary)
    {
        //Get the files from my controller dir
        List<string> controllers = Directory.GetFiles(controllerPath, "*.cs", SearchOption.AllDirectories).ToList<string>();
        //Iterate over my dictionary
        foreach (var entry in dictionary)
        {
            //Build the correct file name using the dictionary key
            string controller = Path.Combine(ControllerPath, entry.Key + "Controller.cs");
            if (File.Exists(controller))
            {
                var regexText = "(?<attribLine>.*)\n" + string.Join("|", entry.Value.Select(t => "[^\n]*public\s[^\n]*" + Regex.Escape(t)))
                var regex = new Regex(regexText)
                //Read the file content and loop over it
                var fileContent = File.ReadAllText(controller);
                foreach (var match in regex.Matches(fileContent))
                {
                     // Here, match.Groups["attribLine"] should contain here what you're looking for.
                }
            }
        }
    }
