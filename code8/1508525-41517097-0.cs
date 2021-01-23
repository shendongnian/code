    private void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True");
        string quary= "select * from ManCash Where USERNAME='"+txtUser.Text+"'and PASS = '"+txtPass.Text+"'";
    SqlCommand cmd=new SqlCommand();
    cmd.CommandText="quary";
    cmd.Connection=con1;
    con1.Open();
    SqlDataReader reader=cmd.ExecuteReader();
    Switch(reader["Role"].toString()){
    case "Manager":
    //redirect to role form
    break;
    case "Cashier1":
    //redirect to role form
    break;
    case "Cashier2":
    //redirect to role form
    break;
    default:
    break;
    }
    con1.Close();
