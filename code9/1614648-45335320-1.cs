     private  async void button1_Click(object sender, EventArgs e)
            {
                await lookingAsync();
            }
    
            public async Task lookingAsync()
            {
                string[] stringArray = { "Ali", "Hasan", "Morad", "Javad" };
    
                foreach (var item in stringArray)
                {
                    
                        label1.Text = item;
                      await  Task.Delay(1000);                                 
                }
                string[] stringArray2 = { "Ali2", "Hasan2", "Morad2", "Javad2", "Mahmood", "Shaparak" };
                foreach (var item in stringArray2)
                {
    
                    label1.Text = item;
                    await Task.Delay(1000);
                }
                  //if you want it in  a loop just uncomment this 
                // await lookingAsync();
            }
