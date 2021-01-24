    private void UpdateTagEditor_RegisterActionEventHandler(object sender, RoutedEventArgs e)
    {
        var tags = sender as UpdateTags;
        string path = tags.targetPath;
        string comments = tags.txtTagComment.Text;
        string lyrics = tags.txtTagLyrics.Text;
        try
        {
            TagLib.Id3v2.Tag.DefaultVersion = 3;
            TagLib.Id3v2.Tag.ForceDefaultVersion = true;
            TagLib.File tagFile = TagLib.File.Create(path);
            tagFile.Tag.Comment = comments;
            tagFile.Tag.Lyrics = lyrics;
            tagFile.Save();
        }
        catch (Exception exception)
        {
        }
    }
