    private void btnFormat_Click(object sender, EventArgs e)
    {
        if(String.IsNullOrWhiteSpace(textBox1.Text) == true) return;
        //searches for the new line character
        Int32 i = textBox1.Text.IndexOf("\r\n");
        Int32 j = 0;
        if (i == -1) return; //new line character not found
        String strA = "";
        String strB = "";
        //now pass the value in 'i' to 'j'
        Int32 icnt = 0;
            
        while(true)
        {
            //j : from where search should begin. Therefore, it is set
            //to a position ahead of last occurence of new line charachter(\r\n)
            //i.e. value in 'i'
            //i : current occurence of new line character
               
            //scan for the next occurence of new line character from
            //current positon
            i = textBox1.Text.IndexOf("\r\n",j);
            if (i == -1) break;
                                
            //there is a possibility of some space(s) or no character at all
            //between the last position and current position, then in such a 
            //case we will remove that newly found new line characters so that
            //the formatting is uniform
            //all text before new line 
            strA = textBox1.Text.Substring(0, i);
            //all textbox after the new line
            strB = textBox1.Text.Substring(i + 2);
            if (String.IsNullOrWhiteSpace(textBox1.Text.Substring(j, i - j)) == 
            false)
            {
                textBox1.Text = strA + "\r\n\r\n" + strB;
                j = i + 4;
            }
            else
            {
                textBox1.Text = strA + strB;
                //do not change the value of 'j'
            }
        }
        //increment i and now again scan from this position
        //for another new line character        
    }
