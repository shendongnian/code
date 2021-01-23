            int[] items = { 1, 3, 4, 9, 2 };
            int[] newItems = new int[items.Length-1];
            var itemtodelete = 4;
            int itemIndex=-1;
            int j = 0, k = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == itemtodelete)
                {
                    itemIndex = i;
                    break;
                }
            }
            
            while (j < items.Length - 1)
            {
                if (k != itemIndex)
                {
                    newItems[j++] = items[k];
                }
                k++;
            }
