        //global declaration    
        
        private List<string> UploadList;
    
        protected void AjaxFileUpload1_UploadComplete()
        {
        	String fileName = IO.Path.GetFileName(e.FileName);
        	UploadList = Session["UploadedFiles"];
        	UploadList.Add(fileName);
        	Session["UploadedFiles"] = UploadList;
        }
        
        //retrieve the items from list
        private void GetList()
        {
        	UploadList = Session["UploadedFiles"];
        	//loop through the list or access each item by the index
        }
