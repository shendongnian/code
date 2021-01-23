        [System.Web.Services.WebMethod]
        public static SubjectList[] GetStudentList(string location, string program, long batch, string term,string code ,string name)
    {
        using (Entities obj = new Entities())
        {
            SubjectListStatus subObjStatus = new SubjectListStatus();
            List<string> rollno = obj.Student_Master.Where(i =>i.Student_Location==location && i.Student_Course==program && i.Student_Batch==batch).Select(i => i.Student_RollNo).ToList();
            foreach (var rollObj in rollno)
            {
                var listLoc = obj.Marks_Master.Where(k => k.Location == location && k.Course_ID == program && k.Subject_ID == code && k.Term_ID == term && k.Student_ID.Equals(rollObj)).ToList();
                foreach (var tempobj in listLoc)
                {
                    SubjectList subObj = new SubjectList();
                    subObj.Subject_Code = tempobj.Student_ID;                   
                    subObj.Total_Obtained = tempobj.Marks_Obtained; ;
                    subObj.Total_Outoff = tempobj.Marks_Total; ;
                    subObjStatus.Add(subObj);
                }
            }
            //return subObjStatus.ToArray();
        // use the below statement to sort by total_obtained in the descending order
           return subObjStatus.OrderByDescending(x=>x.Total_Obtained).ToArray();
        }
    }
