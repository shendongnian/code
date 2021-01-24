     foreach (var item5 in StudentsByTeacherName)
        {
          if (StudentsByTeacherName.ContainsKey(item5.Key))
             {
                //This will add new values on your list of string on specific 
                //keys and will not delete the existing ones:
                List<string> list = StudentsByTeacherName[item5.Key];
                list.Add("Your additional value here");
             }
             else
             {
                StudentsByTeacherName.Add(item4.Value,StudentName);
             }
        }
