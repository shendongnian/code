        private void ExtractFamilyInfo(Application app)
        {
            //A placeholder to store types information
            string types = "Family Types: ";
            //Open Revit Family File in a separate document
            var famDoc = app.OpenDocumentFile(FamilyPath);
            //Get the familyManager instance from the open document
            var familyManager = famDoc.FamilyManager;
            //Get the reference of revit family types
            FamilyTypeSet familyTypes = familyManager.Types;
            //Iterate to the first family type
            FamilyTypeSetIterator familyTypesItor = familyTypes.ForwardIterator();
            familyTypesItor.Reset();
            //Loop through all family types
            while (familyTypesItor.MoveNext())
            {
                FamilyType familyType = familyTypesItor.Current as FamilyType;
                //read all family type names
                types += "\n" + familyType.Name;
            }
            
            //Display text on the UI
            DefaultControl.Instance.PropertyText.Text = types.ToString();
        }
