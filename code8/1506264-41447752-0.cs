    class VModel
    {
        public DataView AlleKunden
        {
            get
            {
                DataTable dt = new DataTable();
                DatabaseConnection connection = new DatabaseConnection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("Select c_name,l_name,a_town,a_pcode,a_street from dbo.AllCustomers", connection.Connection);
                adapter.Fill(dt);
                connection.Connection.Close();
                return dt.DefaultView;
            }
        }
    }
----------
    <ListView Margin="8" Height="350" Width="500" ItemsSource="{Binding AlleKunden}">
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding Path=c_name}" Header="Name" Width="100"/>
                <GridViewColumn DisplayMemberBinding="{Binding Path=l_name}" Header="Standort" Width="100"/>
                <GridViewColumn DisplayMemberBinding="{Binding Path=a_town}" Header="Ort" Width="100"/>
                <GridViewColumn DisplayMemberBinding="{Binding Path=a_pcode}" Header="PLZ" Width="100"/>
                <GridViewColumn DisplayMemberBinding="{Binding Path=a_street}" Header="Straße" Width="100"/>
            </GridView>
        </ListView.View>
    </ListView>
