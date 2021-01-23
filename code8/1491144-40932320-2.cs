    using (var sr = new StreamReader("data\\" + dir + "\\data.ls")){
        string line = string.Empty;
        while((line = sr.ReadLine()) != null) {
            // assume that 1 is username
            if(decusr == textBox1.Text) {
                if( (line = sr.ReadLine()) == decpass == textBox2.Text) {
                    // user is logged in store email
                    UserEmail = sr.ReadLine();
                }
            }
        }
    }
