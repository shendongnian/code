    private static void KeepOnlyBoldFormatting(Word.Document document)
    {
        var undoRecord = document.Application.UndoRecord;
        try
        {
            document.Application.ScreenUpdating = false;
            undoRecord.StartCustomRecord("KeepOnlyBoldFormatting");
            var originalRange = document.Range();
            var originalEnd = originalRange.End - 1; //Skip last character (paragraph marker that cannot be removed)
            originalRange.InsertAfter(originalRange.Text.Substring(0, originalRange.Text.Length - 1));
            //Make sure the ranges refer to the right things
            originalRange.Start = 0;
            originalRange.End = originalEnd;
            var newRange = document.Range(originalEnd, originalEnd + originalEnd);
            for (int i = 1; i <= originalRange.Characters.Count; i++)
            {
                var origChar = originalRange.Characters[i];
                var newChar = newRange.Characters[i];
                if (origChar.Bold == -1)
                    newChar.Bold = -1;
            }
            originalRange.Delete();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            document.Application.ScreenUpdating = true;
            undoRecord.EndCustomRecord();
        }
    }
