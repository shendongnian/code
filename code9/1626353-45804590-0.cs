    public List<Car> CarList = new List<Car>();
    
    private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CarList.Add(new Car((CarType)i, (CarSize)j));
                }
            }
    
            Group1Print(CarList[0], CarList[1], CarList[2]);
            Group2Print(CarList[3], CarList[4], CarList[5]);
            Group3Print(CarList[6], CarList[7], CarList[8]);
        }
