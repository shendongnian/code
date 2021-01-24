    var cour = File.ReadAllLines(@"CourseFile.txt");
    var courFind = cour.Where(g => g.Contains("Course"));
    string[] splited2;
    foreach (var item in courFind)
    {
      splited2 = item.Split(new string[] { "Course:" }, StringSplitOptions.None);
      if(splited2.Length >= 2)
        cbListCourses.Items.Add(splited2[1]);//here is where the issues starts
    }
