        private string DeleteMachineReadableCodeUpdated(string inputFilePath)
        {
        string outputFilePath = Path.Combine(Path.GetTempPath(), string.Format(@"{0}.pdf", Guid.NewGuid()));
    try
    {
        // Open document
        Document pdfDocument = new Document(inputFilePath);
        // Create TextAbsorber object to find all the phrases matching the regular expression
        TextFragmentAbsorber absorber = new TextFragmentAbsorber("#START#((.|\r\n)*?)#END#");
        // Set text search option to specify regular expression usage
        TextSearchOptions textSearchOptions = new TextSearchOptions(true);
        absorber.TextSearchOptions = textSearchOptions;
        // Accept the absorber for all pages
        pdfDocument.Pages.Accept(absorber);
        // Get the extracted text fragments
        TextFragmentCollection textFragmentCollection = absorber.TextFragments;
        // If pattern found on one of the pages
        if (textFragmentCollection.Count > 0)
        {
            RemoveTextFromFragmentCollection(textFragmentCollection);
        }
        else
        {
            // In case nothing was found tries to find by parts
            string startingPattern = "#START#((.|\r\n)*?)\\z";
            string endingPattern = "\\A((.|\r\n)*?)#END#";
            bool isStartingPatternFound = false;
            bool isEndingPatternFound = false;
            ArrayList fragmentsToRemove = new ArrayList();
                    
            foreach (Page page in pdfDocument.Pages)
            {
                // If ending pattern was already found - do nothing
                if (isEndingPatternFound)
                    continue;
                // If starting pattern was already found - activate textFragmentAbsorber with ending pattern
                absorber.Phrase = !isStartingPatternFound ? startingPattern : endingPattern;
                        
                page.Accept(absorber);
                if (absorber.TextFragments.Count > 0)
                {
                    // In case something is found - add it to list
                    fragmentsToRemove.AddRange(absorber.TextFragments);
                    if (isStartingPatternFound)
                    {
                        // Both starting and ending patterns found - the document processing
                        isEndingPatternFound = true;                        
                        RemoveTextFromFragmentCollection(fragmentsToRemove);
                    }
                    else
                    {
                        // Only starting pattern found yet - continue
                        isStartingPatternFound = true;                        
                    }
                }
                else
                {
                    // In case neither starting nor ending pattern are found on current page
                    // If starting pattern was found previously - get all fragments from the page
                    if (isStartingPatternFound)
                    {
                        absorber.Phrase = String.Empty;
                        page.Accept(absorber);
                        fragmentsToRemove.AddRange(absorber.TextFragments);
                    }
                    // Otherwise do nothing (continue)
                }
            }
        }
        pdfDocument.Save(outputFilePath);
    }
    finally
    {
        if (File.Exists(inputFilePath))
            File.Delete(inputFilePath);
    }
    return outputFilePath;
    }
    private void RemoveTextFromFragmentCollection(ICollection fragmentCollection)
    {
    // Loop through the fragments
    foreach (TextFragment textFragment in fragmentCollection)
    {
        textFragment.Text = string.Empty;
    }
    }
