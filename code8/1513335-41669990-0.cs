    var line = reader.ReadLine(); //Read first line
    while(line != null && line != "#") { //check line condition.
        //perform your desired actions
        rslList.Add(line);
        results.Text = results.Text + line + Environment.NewLine; 
        line = reader.ReadLine(); //read the next line
    }
