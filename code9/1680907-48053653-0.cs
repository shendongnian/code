    using System.Text.RegularExpressions;
    ...
    string StripRawFileContentIfExists(string input) {
        string regExPattern = "(?<ContentTypeGroup>Content-Type: .*?\\r\\n\\r\\n)(?<FileRawContentGroup>.*?)(?<NextHeaderBeginGroup>\\r\\n--)";
        return Regex.Replace(input, regExPattern, me => me.Groups["ContentTypeGroup"].Value + string.Empty + me.Groups["NextHeaderBeginGroup"].Value);
    }
    ...
    //apiLogEntry.RequestContentBody = task.Result;
    string requestContentBody = task.Result;
    if(requestContentBody.IndexOf("Content-Type") > 0)
        requestContentBody = StripRawFileContentIfExists(requestContentBody);
    apiLogEntry.RequestContentBody = requestContentBody;
