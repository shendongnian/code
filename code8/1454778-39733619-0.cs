            foreach(var x in RingList)
            {
                int ThePrice = int.Parse(x.Price);
                int TheSize = int.Parse(x.Size);
                if (ThePrice >= 300)
                {
    //  >>> Exception will be throw on next line
                    RingList.Remove(x);
