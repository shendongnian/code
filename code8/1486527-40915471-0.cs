           public bool ItemChecked = false;
           private void TreeListView1_OnNodeCheckStateChanged(object sender, TreeListNodeEventArgs e)
           {
              ItemChecked = true; 
              // To be sure that our code will run only if checkbox have changed
           }
           private void TreeListView1_OnNodeChanged(object sender, TreeListNodeChangedEventArgs e)
           {
              if (ItemChecked)
              {
               // My Code  
              }
             ItemChecked = false;
            }
