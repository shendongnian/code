    List<int> list = new List<int>();
    private void button2_Click(object sender, EventArgs e)
    {         
        int answer = Convert.ToInt32(txt_answer.Text);
        if((num1+num2)==answer)
        {               
            label2.Text="Correct!";
            correctans++;
        }
        else
        {
            label2.Text="Incorrect! correct answer is " + (num1 + num2);
            wrongans++;
        }
        txt_answer.Text = "";
        rnd1.Text = "";
        rnd2.Text = "";
    
        list.Add(num1);
    
        int c = list.Count;
        if(c==10)
        {
            MessageBox.Show("YOUR CORRECT ANSWER ARE  " + correctans + " AND INCORRECT ANSWER ARE  " + wrongans);
            list.Clear();
        }
    }
