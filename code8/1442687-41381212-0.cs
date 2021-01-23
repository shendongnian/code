        void CreateFormResponse()
        {
            FormsManager formsMgr = FormsManager.GetManager();
            formsMgr.Provider.SuppressSecurityChecks = true;
            var form = formsMgr.GetFormByName("sf_stackoverflow");
            if (form != null)
            {
                var entryType = String.Format("{0}.{1}", formsMgr.Provider.FormsNamespace, form.Name);
                FormEntry entry = formsMgr.CreateFormEntry(entryType);
                //here you can populate text fields
                entry.SetValue("FormTextBox_C001", "fieldvalue");
                var documentContentLinks = UploadDocument(entry);
                entry.SetValue("FormFileUpload_C003", documentContentLinks);
                entry.IpAddress = Request.UserHostAddress;
                entry.SubmittedOn = DateTime.UtcNow;
                entry.UserId = ClaimsManager.GetCurrentUserId();
                if (SystemManager.CurrentContext.AppSettings.Multilingual)
                {
                    entry.Language = CultureInfo.CurrentUICulture.Name;
                }
                
                entry.ReferralCode = formsMgr.Provider.GetNextReferralCode(entryType).ToString();
                formsMgr.SaveChanges();
            }
        }
        ContentLink[] UploadDocument(FormEntry entry)
        {
            LibrariesManager libraryManager = LibrariesManager.GetManager();
            var contentLinksManager = ContentLinksManager.GetManager();
            //here you need to choose proper document, or upload your document
            var document = libraryManager.GetDocuments().FirstOrDefault();
            ContentLink contentLink = new ContentLink();
            contentLink.Id = Guid.NewGuid();
            contentLink.ParentItemId = entry.Id;
            contentLink.ParentItemType = entry.GetType().ToString();
            contentLink.ChildItemId = document.Id;
            contentLink.ComponentPropertyName = entry.Id.ToString();
            contentLink.ChildItemAdditionalInfo = "additional info";
            contentLink.ChildItemProviderName = (((IDataItem)document).Provider as DataProviderBase).Name;
            contentLink.ChildItemType = document.GetType().FullName;
            contentLink.ApplicationName = contentLinksManager.Provider.ApplicationName;
            ContentLink[] contentLinks = new ContentLink[0];
            if (contentLinks == null)
            {
                contentLinks = new ContentLink[0];
            }
            var assetsFieldList = contentLinks.ToList();
            assetsFieldList.Insert(0, contentLink);
            return assetsFieldList.ToArray();
        }
