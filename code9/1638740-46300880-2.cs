    DataSet dataSet = new DataSet();
    dataSet.ReadXml(@"C:\Users\Rui\Desktop\myfilename.xml");
    
    //merge all the tables into a single one
    var dtMerged = dataSet.Tables[0].Copy();
    
    for (int i = 1; i < dataSet.Tables.Count; i++)
    {
        dtMerged.Merge(dataSet.Tables[i]);
    }
    //set the datasource using the merged datatable
    dataGridView1.DataSource = dtMerged;
