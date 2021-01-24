    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Reference reference;
            try
            {
                reference = uidoc.Selection.PickObject(ObjectType.Element, "Pick a wall");
            }
            catch
            {
                return Result.Cancelled;
            }
            var element = doc.GetElement(reference);
            if (element == null || !(element is Wall wall))
            {
                TaskDialog.Show("Error", "Selected element was not a wall");
                return Result.Failed;
            }
            using (Transaction trans = new Transaction(doc, "Creating tag"))
            {
                trans.Start();
                CreateIndependentTag(doc, wall);
                trans.Commit();
            }
        }
