    DataSet dataSet = new DataSet();
    dataSet.ReadXml(@"C:\Users\Rui\Desktop\myfilename.xml");
    
    //merge all the tables into a single one
    var dtMerged = ds.Tables[0].Copy();
    
    for (int i = 1; i < ds.Tables.Count; i++)
    {
        dtMerged.Merge(ds.Tables[i]);
    }
    //set the datasource using the merged datatable
    dataGridView1.DataSource = dtMerged;
