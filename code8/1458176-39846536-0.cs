    List<object> list = checkedListBox1.CheckedItems.OfType<object>().ToList();
    List<object> list2 = checkedListBox2.CheckedItems.OfType<object>().ToList();
    List<object> list3 = checkedListBox3.CheckedItems.OfType<object>().ToList();
    List<object> list4 = checkedListBox4.CheckedItems.OfType<object>().ToList();
    List<object> list5 = checkedListBox5.CheckedItems.OfType<object>().ToList();
    
    var allObjects = list.Concat(list2).Concat(list3).Concat(list4).Concat(list5);
    var res = string.Join("&", allObjects);
