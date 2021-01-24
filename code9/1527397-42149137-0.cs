    Minifier min = new Minifier();
    StringBuilder minified = new StringBuilder();
    script.head_files.ForEach(js => {
        if (!string.IsNullOrWhiteSpace(js)) {
            minified.Append(min.MinifyJavaScript(System.IO.File.ReadAllText(Server.MapPath(js))));
            minified.Append(";"); // add this
        }
    });
    if (minified.Length > 0)
    {
        var minJS = Server.MapPath("~/content/template/js/" + objHeads.head_name + "/combined.min.js");
        System.IO.File.WriteAllText(minJS, minified.ToString());
    }
