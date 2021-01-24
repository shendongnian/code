    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        foreach (var link in links)
        {
            var sourceItem = link.GetSourceItem();
            var fieldId = link.SourceFieldID;
            var field = sourceItem.Fields[fieldId];
            string oldIdWithoutBraces = item.ID.ToString().Replace("{", "").Replace("}", "");
            string newIdWithoutBraces = newItem.ID.ToString().Replace("{", "").Replace("}", "");
            string oldIdForHyperlinks = oldIdWithoutBraces.ToLower().Replace("-", "");
            string newIdForHyperlinks = newIdWithoutBraces.ToLower().Replace("-", "");
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
