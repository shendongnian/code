    // Iterate through p tags
    var pTags = htmlDoc.DocumentNode.SelectNodes("//p");
    if (pTags != null)
    {
        foreach (var pTag in pTags)
        {
            // Iterate through bold and italic tags within P tags
            List<string> boldAndItalicTagNames = new List<string>() { "strong", "em" };
            var boldAndItalicTags = pTag.SelectNodes(string.Join("|", boldAndItalicTagNames.Select(x => ".//" + x)));
            if (boldAndItalicTags != null)
            {
                foreach (var tag in boldAndItalicTags)
                {
                    // Remove any other nested tags
                    tag.InnerHtml = tag.InnerHtml.Replace($"<{tag.Name}>", "").Replace($"</{tag.Name}>", "");
                }
            }
        }
    }
