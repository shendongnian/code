            for (int i = 0; i < sizes.Length; i++)
            {
                if (sizes[i] == inputSize)
                {
                    var totalPrice = prices[i] + (inputToppings == "Y" ? extra[i] : 0);
                    Console.WriteLine("You ordered a {0} pizza that costs {1:C}.", sizes[i], totalPrice);
                    break;
                }
            }
