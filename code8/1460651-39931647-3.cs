     protected void Button1_Click(object sender, EventArgs e)
            {
    
    
                //Showing stringJSON in single line
                // First double quotes in below line indicates beginning of JSON string and last Double quotes indicate end of the string
                // Other Doubles quotes are part of the string , they are precededby backslash so we are escaping that double quotes
                //string jsonString = "[{\"ID\":\"27\",\"UserID\":\"1\",\"Name\":\"test1\",\"Description\":\"test1description\",\"StartTime\":\"\"},{\"ID\":\"29\",\"UserID\":\"1\",\"Name\":\"w\",\"Description\":\"ww\",\"StartTime\":\"12\"},{\"ID\":\"30\",\"UserID\":\"1\",\"Name\":\"qq\",\"Description\":\"qqqdescription\",\"StartTime\":\"1222\"},{\"ID\":\"31\",\"UserID\":\"1\",\"Name\":\"v\",\"Description\":\"vv\",\"StartTime\":\"1\"},{\"ID\":\"32\",\"UserID\":\"1\",\"Name\":\"n\",\"Description\":\"nnn\",\"StartTime\":\"111\"}]";
                //Showing stringJSON in multi  line
                string jsonString = "[{\"ID\":\"27\",\"UserID\":\"1\",\"Name\":\"test1\",\"Description\":\"test1description\",\"StartTime\":\"\"} " +
                     " ,"  + " {\"ID\":\"29\",\"UserID\":\"1\",\"Name\":\"w\",\"Description\":\"ww\",\"StartTime\":\"12\"}" +
                    "," + " {\"ID\":\"30\",\"UserID\":\"1\",\"Name\":\"qq\",\"Description\":\"qqqdescription\",\"StartTime\":\"1222\"}" +
                    "," + "{\"ID\":\"31\",\"UserID\":\"1\",\"Name\":\"v\",\"Description\":\"vv\",\"StartTime\":\"1\"}" +
                    "," + "{\"ID\":\"32\",\"UserID\":\"1\",\"Name\":\"n\",\"Description\":\"nnn\",\"StartTime\":\"111\"}]";
    
                
              JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
             List<Employee> listEmployee=  (List<Employee>)javaScriptSerializer.Deserialize(jsonString, typeof(List<Employee>));
    
                // convert list of employees to datatable
    
              DataTable dt1=  ConvertToDatatable(listEmployee);
    
                           
                // Bind to datagrid 
                GridView1.DataSource = dt1;
                GridView1.DataBind();
    
                         
             
               
    
            }
