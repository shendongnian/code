        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //iterate list box items on a thread-pool thread using TPL
                Task.Run(() => Play());
            }
        }
        private void Play()
        {
            //listBox1 is the name of the list box control in my windows forms application
            foreach (var listboxItem   in listBox1.Items)
            {
                //check if the checkbox is currently in checked state
                if(checkBox1.Checked)
                {
                    //Checkbox is checked so process the listbox item
                    Console.WriteLine(listboxItem.ToString());
                    //do other required stuff
                }
                else
                break;    
            }
            
        }
