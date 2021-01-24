    public double getBasePrice()
    {
         typeChoice = 0;
         if (rdCar.Checked)
         {
            typeChoice = 19150;
         }
         else if (rdTruck.Checked)
         {
            typeChoice = 29475;
         }
         else if (rdSUV.Checked)
         {
            typeChoice = 30595;
         }
         else if (rdMinivan.Checked)
         {
            typeChoice = 28155;
         }
         return typeChoice;
     }
