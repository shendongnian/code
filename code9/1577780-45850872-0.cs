    using AngleSharp;
    using AngleSharp.Parser.Html;
    using AngleSharp.Dom; // For IComment
    using AngleSharp.Extensions; // For Descendents
    
    var parser = new HtmlParser();
    var source = @"<!-- Single line comment. -->
                   <!-- Multi-
                   ple line comment.
                   Lots      '""""' '  ""  ` ~ |}{556             of      !@#$%^&*())        lines
                   in
                   this
                   comme -
                    nt!-->";
    var document = parser.Parse(source);
    
    // Get all comment nodes
    IEnumerable<IComment> comments = document.Descendents<IComment>();
    // Get the text in the comment nodes
    foreach (IComment comment in comments)
    {
        var textValue = comment.TextContent;
        ...
    }
