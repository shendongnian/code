    foreach (var item in courFind)
    {
       splited2 = item.Split(new string[] { "Course:" }, StringSplitOptions.None);
       cbListCourses.Items.Add(splited2[0]); // Array Index starts with 0
    }
