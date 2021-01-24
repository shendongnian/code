     //Get any range you want
    var range = app.ActiveDocument.StoryRanges[WdStoryType.wdMainTextStory];
    var document = range.Document;
    //We want the variable range to continue refering to the same Range at all times
    var foundRange = range.Duplicate;
    if (foundRange.Find.Execute("j", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, WdFindWrap.wdFindStop, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)) {
        Console.WriteLine("Found first");
        //After using .Execute(), FoundRange has been set to the found text
        Console.WriteLine(foundRange.Text);
    }
    else
    {
        Console.WriteLine("Didn't find first");
    }
    //Set foundRange to start at the character after the last find and to end where the original range ends
    foundRange = document.Range(foundRange.Start + 1, range.End);
    //Repeat. Obviously you could use some kind of loop
    if (foundRange.Find.Execute("j", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, WdFindWrap.wdFindStop, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing))
    {
        Console.WriteLine("Found second");
        Console.WriteLine(foundRange.Text);
    }
    else
    {
        Console.WriteLine("Didn't find second");
    }
    foundRange.Select(); //Just to verify. We don't need the selection object for anything
