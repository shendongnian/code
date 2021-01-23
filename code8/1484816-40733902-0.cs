    [System.Web.Services.WebMethod]
        //change to IEnumerable instead of array
        public static IEnumerable<SubjectList> GetStudentList(string location, string program, long batch, string term,string code ,string name)
    {
        using (Entities obj = new Entities())
        {
            //If all subObjStatus did is keeping the SubjectList, you don't really need it
            //SubjectListStatus subObjStatus = new SubjectListStatus();
            //Don't store it into list, just keep it lazy loaded
            var rollno = obj.Student_Master.Where(i =>i.Student_Location==location && i.Student_Course==program && i.Student_Batch==batch).Select(i => i.Student_RollNo);
            foreach (var rollObj in rollno)
            {
                //same thing here, keep it lazy loaded
                var listLoc = obj.Marks_Master.Where(k => k.Location == location && k.Course_ID == program && k.Subject_ID == code && k.Term_ID == term && k.Student_ID.Equals(rollObj));
                foreach (var tempobj in listLoc)
                {
                    SubjectList subObj = new SubjectList();
                    subObj.Subject_Code = tempobj.Student_ID;                   
                    subObj.Total_Obtained = tempobj.Marks_Obtained; ;
                    subObj.Total_Outoff = tempobj.Marks_Total;
                    subObj.Subject_Name = //you probably want the name too 
                    yield return subObj;
                }
            }
           
        }
    }
  
