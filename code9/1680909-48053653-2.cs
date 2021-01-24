    using System.Text.RegularExpressions;
    ...
    string StripRawFileContentIfExists(string input) {
        if(input.IndexOf("Content-Type") == -1)
            return input;
        string regExPattern = "(?<ContentTypeGroup>Content-Type: .*?\\r\\n\\r\\n)(?<FileRawContentGroup>.*?)(?<NextHeaderBeginGroup>\\r\\n--)";
        return Regex.Replace(input, regExPattern, me => me.Groups["ContentTypeGroup"].Value + string.Empty + me.Groups["NextHeaderBeginGroup"].Value);
    }
    ...
    //apiLogEntry.RequestContentBody = task.Result;
    apiLogEntry.RequestContentBody = StripRawFileContentIfExists(task.Result);
