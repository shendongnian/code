     private void button1_Click(object sender, EventArgs e)
    {
        string directory = @"C:\Users\fatih\AppData\Local\Temp";
        foreach (string file in directory.GetFiles()) {
        try{
          File.Delete(file);
        }
        catch(Exception e0){
            Console.WriteLine(e1.Messgae+"\n"+e1.Source);//not necessary but nice to learn from
        }
        foreach (string direc in directory.GetDirectories()) 
        try{
           Directory.Delete(direc,true);
        }
        catch(Exception e1){
            Console.WriteLine(e1.Messgae+"\n"+e1.Source);//not necessary but nice to learn from
        }
    }
