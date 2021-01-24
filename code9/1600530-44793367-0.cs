    dynamic input;
    using (var reader = new StreamReader(jsonFile))
    {
        input = JObject.Parse(reader.ReadToEnd(), new JsonLoadSettings() { CommentHandling = CommentHandling.Ignore, LineInfoHandling = LineInfoHandling.Ignore });
    }
    var obj = new SomeObject();
    obj.Field = input.submitter.hierachies[0].SomeProperty
