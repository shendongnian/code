     private void FindDevice_Executed(object sender, ExecutedRoutedEventArgs e)
        {    
            var RegisterLowByte = BitConverter.GetBytes(infoRegisters[j])[0];
            var hasItem = sdb.GetProductFilteredWithLinq(RegisterLow);
            if (hasItem != null)
            {
                foreach (var item in hasItem)
                {
                  lb_Configuration.Items.Add(item);
                }
            }
            else
            {
                ...
            }
        }
