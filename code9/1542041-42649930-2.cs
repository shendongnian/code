    private void FindProduct()
    {
     var numbers = new List<int>();
     for (int i = 999; i > 99; i--)
     {
        for (int j = 999; j > 99; j--)
        {
            var product = i * j;
            var productString = product.ToString();
            var reversed = product.Reverse();
            if (product == reversed)
            {
                   numbers.Add(product);
            }
         }
       }
       Console.WriteLine(numbers.Max());
    }
