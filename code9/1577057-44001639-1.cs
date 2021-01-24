    if (SmartCopyLoad.ResetSelection)
    {
        ICollection<ElementId> elementIds = uiDoc.Selection.GetElementIds();
        elementIds.Clear();
        foreach (Element One_Element in SmartCopy.MatchingElements) { elementIds.Add(One_Element.Id); }
        uiDoc.Selection.SetElementIds(elementIds);
        return Autodesk.Revit.UI.Result.Succeeded;
    }
