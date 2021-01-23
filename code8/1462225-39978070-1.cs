        static void Main(string[] args)
        {
            //current line from the file
            string line;
            
            //filereader
            using (var file = new StreamReader("C:\\Users\\adamoui\\Desktop\\Statjbm_20161009.txt"))
            {
                //list for the first columns
                var firstColumnInFile = new List<string>();
                //read every line 
                while ((line = file.ReadLine()) != null)
                {
                    //split line
                    var items = line.Split('|');
                    // add the first column in the list;
                    firstColumnInFile.Add(items.First());
                }
                if(firstColumnInFile.Count < 4)
                    return;
                SqlCommand cmdJBM = new SqlCommand(@"INSERT INTO dbo.StatJBM_NEW
                                    (Noeud, Total_MT, Date, DELIVERED, EXPIRED,
                                    UNDELIVERABLE) VALUES (@Noeud, @Total_MT, @Date,
                                    @DELIVERED, @EXPIRED, @UNDELIVERABLE)", con);
                cmdJBM.Parameters.AddWithValue("@Noeud", "JBM");
                cmdJBM.Parameters.AddWithValue("@DELIVERED", firstColumnInFile[0]); //first column
                cmdJBM.Parameters.AddWithValue("@EXPIRED", firstColumnInFile[1]); //second column
                cmdJBM.Parameters.AddWithValue("@UNDELIVERABLE", firstColumnInFile[2]); //third column
                cmdJBM.Parameters.AddWithValue("@Total_MT", firstColumnInFile[3]); //...
                cmdJBM.Parameters.AddWithValue("@Date", DateTime.Now.AddDays(-1));
            }
        }
    }
