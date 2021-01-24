    int count = 0;
    Button first = null;
    
    private void button1_Click(object sender, EventArgs e)
    {
        buttonClick(sender);
    }
    
    private void buttonClick(object sender)
    {
      count++;
      if (count == 1)
      {
        first = sender as Button;
      }
      else if(count == 2)
      {
        swap(sender);
        resetCount();
      }
    }
    
    private void swap(object sender)
    {
      if(first != null) //just in case, but it should not happen
      {
        Button second = sender as Button;
        string aux = second.Text;
        second.Text = first.Text;
        first.Text = aux;
      }
    }
    
    private void resetCount()
    {
        count = 0;
    }
