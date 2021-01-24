    public static class Speed
    {
         public static float AverageSpeed;
         public static float MaxSpeed;
         public static float MinSpeed;
    }
    Form1_Load()
    {
         label1.Text = Speed.AverageSpeed.ToString('0.0');
    }
    
    Form2_Load()
    {
         label2.Text = Speed.MaxSpeed.ToString('0.0');
    }
