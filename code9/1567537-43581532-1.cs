    int index = 0;
    private void inputBox_KeyDown(object sender, KeyEventArgs e)
    {
    
        if (e.KeyCode == Keys.Enter){
            itemHandler();
            inputBox.Clear();
        }
        // you should check here whether your index is between 0 and reload.Count-1
        if (reload.Count > 0 && index > 1 && index < reload.Count -1){
    
            if (e.KeyCode == Keys.Up){
                x++;
            }
    
            if (e.KeyCode == Keys.Down)(
                x--;
            }
    
            inputBox.Text = reload[index]; 
    
        }    
    }
            
