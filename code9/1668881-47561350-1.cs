    private void Form1_Load(object sender, EventArgs e)
    {
        GetDataFromDataBase();
    }
    
    Dictionary<int, int> IdGenderDict;
    private void GetDataFromDataBase()
    {
        // get data from database
        DataTable dt = DAL.DataBase.GetData();
        // set datagridview
        dtGrdAdd.DataSource = dt;
        // initilize dictionary that willl hold key value pair for ID against its gender
        IdGenderDict = new Dictionary<int, int>();
        // set the dictionary
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            IdGenderDict.Add(Convert.ToInt32(dt.Rows[i]["ID"].ToString()),
            Convert.ToInt32(dt.Rows[i]["Gender"].ToString()));
        }
    }
    
    private void dtGrdAdd_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // get the selected id from the datagridview
        var id = Convert.ToInt32(this.dtGrdAdd.Rows[e.RowIndex].Cells["ID"].ToString());
        // find the gender using the dictionary
        var gender = IdGenderDict[id];
        // set the combobox with the gender
        if (gender == 0)
        {
            cmbGender.SelectedItem = "MALE";
        }
        else
        {
            cmbGender.SelectedItem = "FEMALE";
        }
    }
