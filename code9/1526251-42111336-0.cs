     var product = "coffee";
                var city = "VarNa";
                var amount = 10.00;
                double result;
    
                switch (city.ToLower())
                {
                    case "sofia":
                        switch (product)
                        {
                            case "coffee":
                                result = amount * 0.50;
                                Console.WriteLine(result);
                                break;
                            case "water":
                                result = amount * 0.80;
                                Console.WriteLine(result);
                                break;
                            case "beer":
                                result = amount * 1.20;
                                Console.WriteLine(result);
                                break;
                            case "sweets":
                                result = amount * 1.45;
                                Console.WriteLine(result);
                                break;
                            case "peanuts":
                                result = amount * 1.60;
                                Console.WriteLine(result);
                                break;
                        }
                        break;
    
                    case "plovdiv":
                        switch (product)
                        {
                            case "coffee":
                                result = amount * 0.40;
                                Console.WriteLine(result);
                                break;
                            case "water":
                                result = amount * 0.70;
                                Console.WriteLine(result);
                                break;
                            case "beer":
                                result = amount * 1.15;
                                Console.WriteLine(result);
                                break;
                            case "sweets":
                                result = amount * 1.30;
                                Console.WriteLine(result);
                                break;
                            case "peanuts":
                                result = amount * 1.50;
                                Console.WriteLine(result);
                                break;
                        }
                        break;
    
                    case "varna":
                        switch (product)
                        {
                            case "coffee":
                                result = amount * 0.45;
                                Console.WriteLine(result);
                                break;
                            case "water":
                                result = amount * 0.70;
                                Console.WriteLine(result);
                                break;
                            case "beer":
                                result = amount * 1.10;
                                Console.WriteLine(result);
                                break;
                            case "sweets":
                                result = amount * 1.35;
                                Console.WriteLine(result);
                                break;
                            case "peanuts":
                                result = amount * 1.55;
                                Console.WriteLine(result);
                                break;
                            default:
                                Console.WriteLine("Invalid");
                                break;
                        }
                        break;
                }
                
