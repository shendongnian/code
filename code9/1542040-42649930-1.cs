    private void FindProduct()
    {
     for (int i = 999; i > 99; i--)
     {
        for (int j = 999; j > 99; j--)
        {
            var product = (i * j).ToString();
            var reversed = product.Reverse();
            if (product == reversed)
            {
                   Console.Write(product);
                   return;
            }
         }
       }
    }
