    try
    {
        string filename = "../../" + filenametxt.Text;
        StreamReader inputFile = File.OpenText(filename);
        while(!inputFile.EndOfStream)
        {
            studentansArray[index] = inputFile.ReadLine();
            if (studentansArray[index] == answerArray[index])
    	        count++;
            else
    	    {
    	        qnumber = index + 1;
    	        incorrectList.Add(qnumber.ToString());
    	    }
            index++;
        }
        inputFile.Close();
        if (count >= 15)
        {
            resultoutput.Text = "You Passed The Test!";
        }
        else
            resultoutput.Text = "You Failed The Test... You're a Failure!";
        foreach (string str in incorrectList)
        {
            lbox.Items.Add(str);
        }
    }
    catch (Exception)
    {
        MessageBox.Show("File Not Found");
    }
