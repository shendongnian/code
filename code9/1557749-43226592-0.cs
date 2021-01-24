    private void timer1_Tick(object sender, EventArgs e)
        {
             a = list1.Count() - 1;  //Count will return the number of items in the list, you subtract 1 because the indexes start from 0
             list1.RemoveAt(a);
             listBox.Items.Clear();
             foreach(string x in list1)
             {
                  listBox.Items.Add(x);
             }
        }
