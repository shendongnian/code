    var Index=0; 
        public void ClickNext()
         {
                List<int> test = new List<int>();
               for(int i=0;i<=2;i++)
               {
                test.Add(i);
            //test.Add(0);
           // test.Add(1);
           // test.Add(2);
                
               }      
              if(Index<=test.Last())
                 {
                   MessageBox.Show(test[Index].ToString());
                 }
              else{
                  MessageBox.Show("End");
                 //reset Index
                 Index=0; 
                 }
        }
            
         private void buttonRight_Click(object sender, RoutedEventArgs e)
            {
               
               u1.ClickNext();
              Index++;
            }
