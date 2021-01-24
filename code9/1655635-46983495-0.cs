     listView1.Items.Clear();
            try
            {
        //"" is a blank search which will return all files. 
        //But could easily be a value from a textbox. It is loaded into the Array Files
                var files = db.FileStorage.Find("").ToArray();
               
        //go through each obj in the array and abstract FileName, ID and 
        //Created date, adding them each to a new array (mylist, mylist1 etc.)
    foreach (object obj in files)
                {
                  
                    mylist = files.Select(I => Convert.ToString(I.Filename)).ToArray();
                    mylist1 = files.Select(I => Convert.ToString(I.UploadDate)).ToArray();
                    mylist2 = files.Select(I => Convert.ToString(I.Id)).ToArray();
                }
     //loop through the mylist arrays an create usable strings for each value.
                for (int i = 0; i < mylist.Length; i++)
                {
                    name = mylist[i].ToString();
                    datecreated = mylist1[i].ToString();
                    id = mylist2[i].ToString();
     //add each value to a listview
                    listView1.Items.Add(new ListViewItem(new string[] { name, datecreated,id }));
                }
