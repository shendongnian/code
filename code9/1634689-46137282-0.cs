     public int practice(List<int> items)
        {
            if (items == null || items.Count <= 1)
            {
                return 0;
            }
            else
            {
                int second_place = items[1];
                return second_place;
            }
        }
