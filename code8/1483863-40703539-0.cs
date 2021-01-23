        private void BubbleSort()
        {
            int a = lstHoldValue.Items.Count;
            for (int i = 0; i < a - 1; i++)
            {
                var k = 0;
                for(var j = 1; j < a - i; j++)
                {
                    if (Convert.ToInt32(lstHoldValue.Items[j]) < Convert.ToInt32(lstHoldValue.Items[k]))
                    {
                        var temp = lstHoldValue.Items[j];
                        lstHoldValue.Items[j] = lstHoldValue.Items[k];
                        lstHoldValue.Items[k] = temp;
                        k = j;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
        }
