    public string CreateSheet()
        {
            string siteUrl = SPContext.Current.Site.Url;
            string retval = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite sc = new SPSite(siteUrl))
                {
                    using (SPWeb web = sc.OpenWeb())
                    {
                        SPFile spFile = web.GetFile("SiteCollectionDocuments/Template.xlsx");
                        Stream stream = spFile.OpenBinaryStream();
                        using (ExcelPackage p = new ExcelPackage(stream))
                        {
                            ExcelWorksheet sheetRoles = p.Workbook.Worksheets["Roles"];
                            sheetRoles.Cells[2, 1].Value = "Today: " + DateTime.Now.ToString("dd.MM.yyyy");
                            byte[] data = p.GetAsByteArray();
                            stream.Close();
                            web.AllowUnsafeUpdates = true;
                            SPDocumentLibrary lib = web.Lists.TryGetList("Site Collection Documents") as SPDocumentLibrary;
                            string fileName = "TheNewFileNameToUse-" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
                            lib.RootFolder.Files.Add("SiteCollectionDocuments/" + fileName, data, true);
                            retval = siteUrl + "/_layouts/15/WopiFrame.aspx?sourcedoc=/SiteCollectionDocuments/" + fileName + "&action=default";
                        }
                    }
                }
            });
            return retval;
        }
