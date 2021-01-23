    private static void DoExcel()
        {
            var application = new Application();
            var workbook = application.Workbooks.Add();
            var worksheet = workbook.Worksheets.Add();
            
            // Name that this will be saved as
            string name = workbook.FullName + ".xlsx";
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), name);
            // If a file of the same name exists, delete it so that we won't be prompted if
            // we want to overwrite it when we save
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            // Save the workbook - otherwise we may be prompted as to whether we want to save when we go to quit
            workbook.Save();
            // Quit the application
            application.Quit();
            // Release the references
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(application);
            // Release the .NET reference and run the garbage collector now to make sure the application is closed immediately
            worksheet = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
