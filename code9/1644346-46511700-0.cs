        namespace ConsoleApp2
        {
            class Numbers
            {
                public static void Cost(float cost, int height, int weight)
                {
                    //Calculating the price of it
                    float result = cost * weight * height;
                    Console.WriteLine(result + "is the price");
                }
            }
            class Program
            {
        
                static void Main(string[] args)
                {
                    int height, weight;
                    height = 5;
                    weight = 10;
                    float cost = 0.5f;
                    Numbers Numbers = new Numbers();
                    Numbers.Cost(cost, height, weight );
                    Console.ReadLine();
                }
            }
        }
