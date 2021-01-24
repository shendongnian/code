        Class APIResponse<T> 
        {        
            public bool IsError;
            
            public int ErrorCode;
            
            public string ErrorMessage;
            
            public T ReponseData; 
        }
        public string getList(string strSalary)
        {
        List<Employee> listJson = null;
        APIResponse<Employee> responseString = new  APIResponse<Employee>();
        try
        {
            listJson = ReportBLL.getInstance.listEmployees(int.Parse(strSalary));
            responseString.isError = false;
            responseString.data = JArray.FromObject(listJson);
        }
        catch (Exception ex)
        {
         responseString.IsError = true;
         responseString.ErrorCode = 404;
         responseString.ErrorMessage = "Record Not Found";
        }
        return JsonConvert.SerializeObject(responseString);
        }
