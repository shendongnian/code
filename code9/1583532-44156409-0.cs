     //this will create a variable that belongs to no class
     private static string id;
     //This will create a get property for the variable "id"
     public static string ID{get{return id;}}
     if (dt.Rows[0][0].ToString() == "1")
     {
            id = "YOUR ID";
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
     }
