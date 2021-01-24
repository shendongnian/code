    async Task Button_Search_Click(object sender, EventArgs e)()
    {
        DisableInput(); //Block input on start of function
        Cursor.Current = Cursors.WaitCursor; //set wait cursor
    
        //read combobox input
        string objectType = comboBox_Object.SelectedItem.ToString();
        string conditionType = comboBox_ConditionType.SelectedItem.ToString();
        string conditionOperator = comboBox_equals.SelectedItem.ToString();
    
        //create a list of worker threads
        List<Task> workerTasks = new List<Task>();
    
        //for each line in the textbox
        foreach (string searchText in textBox_SearchText.Lines)
        {
            if (String.IsNullOrWhiteSpace(searchText)) continue;
    
             //foreach line in a listbox
            foreach (String uri in Get_selected_sites())
            {
                string cred = (creddict[uri]);
    
                workerTasks.Add(Task.Run(() => Search(uri, cred, objectType, conditionType, conditionOperator, searchText)));
            }
            await Task.WhenAll(workerTasks);
        }
    
        Displaydata();
        EnableInput(); //unlock input
        Cursor.Current = Cursors.Default; //set normal cursor
    }
