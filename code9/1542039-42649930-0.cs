    private void FinProduct()
    {
     for (int i = 999; i > 0; i--)
     {
        for (int j = 999; j > 0; j--)
        {
            var product = (i * j).ToString();
            var reversed = product.Reverse();
            if (product == reversed)
                   Console.Write(product);
                   return;
         }
       }
    }
