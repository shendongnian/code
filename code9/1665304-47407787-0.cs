     var cbListStudents = new List<String> ();
     var cbListCourses = new List<String> ();
     var d = File.ReadAllLines (@"res/TestFile.txt");
     var t = d.Where (g => g.Contains ("Student Name"));
     string[] splited;
     foreach (var item in t) {
        splited = item.Split (new string[] { "Student Name:" }, StringSplitOptions.None);
        cbListStudents.Add (splited[1]);
     }
     var cour = File.ReadAllLines (@"res/TestFile2.txt");
     var courFind = cour.Where (g => g.Contains ("Course"));
     string[] splited2;
     foreach (var item in courFind) {
        splited2 = item.Split (new string[] { "Course:" }, StringSplitOptions.None);
        cbListCourses.Add (splited2[1]); //here is where the issues starts
     }        
