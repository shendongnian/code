     public ActionResult Export(int? protocol, int? visitno)
        {
            //creating file here
            if (!string.IsNullOrEmpty(csvData))
            {
                return File(new System.Text.UTF8Encoding().GetBytes(csvData), "text/csv", "Sample.csv");
                TempData["SuccessMessage"] = "Your success message here";        
            }
            if(no file created)
            {
                TempData["ErrorMessage"] = "Your error message here";
            }
        }
