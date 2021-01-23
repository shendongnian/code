    public Form1()
            {
                InitializeComponent();
                 Dim VB = ConfigurationManager.ConnectionString["HMDB"].ConnectionString
                Using Con = New SqlConnection(VB)
                Dim SqlText = "Select DocEntry from dbo.Master1"
                Dim cmd = New SqlCommand(SqlText, Con)
                Con.Open()
                ComboBox1.DataSource = cmd.ExecuteReader()
                ComboBox1.DataBind()
                End Using           
            }
