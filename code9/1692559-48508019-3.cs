    public static void BatteryStatusThread() //THIS IS THE THREAD THAT SHOULD UPDATE THE BATTERY PERCENTAGE IN THE LABEL VIA labelBattery.Text
        {
            Debug.WriteLine("BatteryThread entered");
            while (true)
            {
                int batteryVal = GetBatteryStatus();
                Form1 form = new Form1(); //Create instance here
                form.labelBattery.Text = batteryVal.ToString(); 
                Thread.Sleep(1000);
            }
        }
