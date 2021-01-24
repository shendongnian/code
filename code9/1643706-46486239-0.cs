    Thread thrCreate = new Thread(createThread);
    thrCreate.SetApartmentState(ApartmentState.STA);
    thrCreate.Start();
    private void createThread()
    {
        IEdmAddCustomRefs2 pdmRefs = (IEdmAddCustomRefs2)vault2.CreateUtility(EdmUtility.EdmUtil_AddCustomRefs);
        IEdmFile5 pdmRefFile = (IEdmFile5)pdmResult;        
        string[] strRefPath = new string[1];
        strRefPath[0] = strPDFPath + strSerName + ".pdf";
        pdmRefs.AddReferencesPath(pdmRefFile.ID, ref strRefPath);
    }
