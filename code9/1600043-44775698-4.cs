            private void ImgToDataGridView()
            {
                /* List of path of img */
                List<string> pathImgUpload = new List<string>();
                List<string> pathNotInsert = new List<string>();
    
                /* Just for my test */
                pathImgUpload.Add("./abc.png");
                pathImgUpload.Add("./abc.png");
                pathImgUpload.Add("./abc.png");
                pathImgUpload.Add("./abc.png");
    
                pathNotInsert.Add("./abc.png");
                pathNotInsert.Add("./abc.png");
                pathNotInsert.Add("./abc.png");
                pathNotInsert.Add("./abc.png");
                pathNotInsert.Add("./abc.png");
    
                /* Creation of columns for the good and bad img */
                DataGridViewImageColumn colImgUpload = new DataGridViewImageColumn();
                DataGridViewImageColumn colImgNotInsert = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(colImgUpload);
                dataGridView1.Columns.Add(colImgNotInsert);
    
                /* Max of size of pathImgUpload and pathNotInsert */
                var lineadd = pathImgUpload.Count > pathNotInsert.Count ? pathImgUpload.Count : pathNotInsert.Count;
                
                /* Create the good number of line (-1 because a first line is already in datagridview)*/
                for(int i = 0; i <lineadd - 1; i++)
                {
                    dataGridView1.Rows.Add();
                }
                
                /* adding good img */
                for (int i = 0; i < pathImgUpload.Count(); i++)
                {
                    string path = pathImgUpload[i];
                    var img = new Bitmap(path);
                    dataGridView1.Rows[i].Cells[0].Value = img;
                }
    
                /* adding bad img */
                for(int i = 0; i < pathNotInsert.Count();i++)
                {
                    string path = pathNotInsert[i];
                    var img = new Bitmap(path);
                    dataGridView1.Rows[i].Cells[1].Value = img;
                }
            }
