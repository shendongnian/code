    public partial class RecieveOrder : Form
    {
    
        DataTable dy = new DataTable();
        reatail r = new reatail();
        Thread t;
        public void storeToStock()
        {
            //DataTable dy = new DataTable();
            Thread th=new Thread(()=>dy=r.loadAllOrder());
            th.Start();
            //wait for the thread to finish its execution and get the data from backend DB.
            th.Join();
            //now iterate the rows retrieved from DB
            foreach(DataRow row in dy.Rows)
            {
                MessageBox.Show(row[0].ToString());
            }
        }
    }
