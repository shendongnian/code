    private void Form1_Load(object sender, EventArgs e)
    {
        SemMajAxTab_InputBodyRadius_ComboBox.Items.Clear();
        OPTab_InputBodyMass_ComboBox.Items.Clear();
        OPTab_InputBodyMass2_ComboBox.Items.Clear();
        OPTab_InputBodyRadius_ComboBox.Items.Clear();
        HohTab_InputBodyMass_ComboBox1.Items.Clear();
        HohTab_InputBodyRadius_ComboBox1.Items.Clear();
        HohTab_InputBodyMass_ComboBox2.Items.Clear();
        HohTab_InputBodyRadius_ComboBox4.Items.Clear();
        CelestialBodyData[] celestialbodydata_Array = JsonConvert.DeserializeObject<CelestialBodyData[]>(File.ReadAllText(@"C:\Users\Anase\Desktop\Visual C\KMAP\KMAP\bin\Release\celestialbodydata.json"));
        string[] namesarray = new string[celestialbodydata_Array.Length];
    
        for (int i = 0; i < celestialbodydata_Array.Length; i++)
        {
            namesarray[i] = (celestialbodydata_Array[i].name).ToString();
        }
        SemMajAxTab_InputBodyRadius_ComboBox.Items.AddRange(namesarray);
        OPTab_InputBodyMass_ComboBox.Items.AddRange(namesarray);
        OPTab_InputBodyMass2_ComboBox.Items.AddRange(namesarray);
        OPTab_InputBodyRadius_ComboBox.Items.AddRange(namesarray);
        HohTab_InputBodyMass_ComboBox1.Items.AddRange(namesarray);
        HohTab_InputBodyRadius_ComboBox1.Items.AddRange(namesarray);
        HohTab_InputBodyMass_ComboBox2.Items.AddRange(namesarray);
        HohTab_InputBodyRadius_ComboBox4.Items.AddRange(namesarray);
    }
