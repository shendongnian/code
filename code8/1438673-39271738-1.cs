    public void EA_OnContextItemChanged(EA.Repository Repository, string GUID, EA.ObjectType ot)
        {
            
            EA.Element addedElement = Repository.GetElementByGuid(GUID);
            if (addedElement == null)
                return;
            int identifiedParentID = 0;
            bool isAvailable = lstChildElements.TryGetValue(addedElement.ElementID, out identifiedParentID);
            if (!isAvailable)
            {
                if (addedElement.Stereotype == "Child" && addedElement.ParentID != 0)
                {
                    EA.Element parentElemnt = Session.Repository.GetElementByID(addedElement.ParentID);
                    if (parentElemnt != null)
                        if (parentElemnt.Stereotype == "anyCustomDefined")
                            lstChildElements.Add(addedElement.ElementID, addedElement.ParentID);
                }
            }
        }
        public void EA_OnNotifyContextItemModified(EA.Repository Repository, string GUID, EA.ObjectType ot)
        {
            EA.Element addedElement = Repository.GetElementByGuid(GUID);
            if (addedElement == null)
                return;
            int identifiedParentID = 0;
            bool isAvailable = lstChildElements.TryGetValue(addedElement.ElementID, out identifiedParentID);
            if (isAvailable)
            {
                if (addedElement.Stereotype == "Child" && addedElement.ParentID != 0)
                {
                    EA.Element parentElemnt = Repository.GetElementByID(addedElement.ParentID);
                    if (parentElemnt != null)
                        if (parentElemnt.Stereotype != "anyCustomDefined")
                        {
                            addedElement.ParentID = identifiedParentID != 0 ? identifiedParentID : addedElement.ParentID;
                            addedElement.Update();
                            lstChildElements[addedElement.ElementID] = addedElement.ParentID;
                        }
                }
                else if (addedElement.Stereotype == "Child" && addedElement.ParentID == 0)
                {
                    addedElement.ParentID = identifiedParentID;
                    addedElement.Update();
                }
            }
        }
