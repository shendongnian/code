    private void button1_Click(object sender, EventArgs e)
    {
        string directory = @"C:\Users\fatih\AppData\Local\Temp";
        deleteDirectory(directory);
    }
    private void deleteDirectory(string directory){
        foreach (string file in Directory.GetFiles(directory)) 
        {
            try{
                 File.Delete(file);
            }
            catch(Exception e0){
            Console.WriteLine(e0.Message+"\n"+e0.Source);//not necessary but nice to learn from
            }
        }
        foreach (string direc in Directory.GetDirectories(directory)) {
              deleteDirectory(direc);
              Directory.Delete(direc,true);
        }
    }
