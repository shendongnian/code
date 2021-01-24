    protected void Page_Load(object sender, EventArgs e)
    {
        List<MyDataModel> data = new List<MyDataModel> {
            new MyDataModel { Color = Color.LightBlue, Label = "Value 1", Value = 100 },
            new MyDataModel { Color = Color.LightBlue, Label = "Value 2", Value = 100 },
            new MyDataModel { Color = Color.LightBlue, Label = "Value 3", Value = 100 },
            new MyDataModel { Color = Color.Blue, Label = "Value 4", Value = 100 },
            new MyDataModel { Color = Color.Blue, Label = "Value 5", Value = 400 },
        };
            foreach (MyDataModel dm in data)
            {
                Chart1.Series[0].Points.Add(new DataPoint
                {
                    Color = dm.Color,
                    Label = dm.Value.ToString(),
                    YValues = new double[] { dm.Value }
                });
                Chart1.Series[1].Points.Add(new DataPoint
                {
                    Color = Color.Transparent,
                    Label = dm.Label,
                    YValues = new double[] { dm.Value }
                });
            }
    }
