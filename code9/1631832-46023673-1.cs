    var sectionCharacters = File.ReadLines("your_filepath_here").ToList();
    
    //To remove '=='
    sectionCharacters.Where(i => i.Trim() == "==").ToList()
                     .ForEach(item => sectionCharacters.Remove(item));
    //To remove 'blank lines', if any
    sectionCharacters.Where(i => i.Trim() == "").ToList()
                     .ForEach(item => sectionCharacters.Remove(item));
    for (int i = 0; i < sectionCharacters.Count; i += 2)
    {
        ListViewItem lvi = new ListViewItem();
        lvi.Text = sectionCharacters[i];
        lvi.SubItems.Add(sectionCharacters[i + 1]);
        listView1.Items.Add(lvi);
    }
