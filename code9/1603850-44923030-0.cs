     private void FindDevice_Executed(object sender, ExecutedRoutedEventArgs e)
        {    
            var RegisterLowByte = BitConverter.GetBytes(infoRegisters[j])[0];
            var hasItem = sdb.GetProductFilteredWithLinq(RegisterLow);
            if (hasItem != null)
            {
                lb_Configuration.Items.AddRange(hasItem);
            }
            else
            {
                ...
            }
        }
