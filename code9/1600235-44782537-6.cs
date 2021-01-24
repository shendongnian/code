        string numberPlate = "21323412";
        string path = @"C:\tmp\";
        private void button2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(path + numberPlate); //to create folder
            string dirpath = path + numberPlate; //to get name of fodler we created
            string filename = Guid.NewGuid().ToString();
            pictureBox1.Image.Save(dirpath + @"\"+filename+".jpeg", ImageFormat.Jpeg); //to save picturebox image in folder
        }
