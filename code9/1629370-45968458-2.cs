    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        foreach (var link in links)
        {
            var sourceItem = link.GetSourceItem();
            var fieldId = link.SourceFieldID;
            var field = sourceItem.Fields[fieldId];
            sourceItem.Editing.BeginEdit();
            try
            {
                field.Value = field.Value
                    .Replace(oldIdWithoutBraces, newIdWithoutBraces)
                    .Replace(oldIdForHyperlinks, newIdForHyperlinks);
            }
            catch
            {
                sourceItem.Editing.CancelEdit();
            }
            finally
            {
                sourceItem.Editing.EndEdit();
            }
        }
    }
