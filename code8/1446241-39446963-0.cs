            int userValue, rad, heightOfRectangle, widthOfRectangle, baseOfTriangle, heightOfTriangle;
            double area;
            Console.Write("\n\n");
            Console.Write("Calculating Area of Geometrical Shape\n");
            Console.Write("=======================================\n");
            Console.Write("\n\n");
            Start:
            Console.Write("Please select 1 for Circle, 2 for Rectangle and 3 for Triangle: ");
            userValue = Convert.ToInt32(Console.ReadLine());
            switch (userValue)
            {
                case 1:
                    Console.Write("Please Enter Radius of Circle: ");
                    rad = Convert.ToInt32(Console.ReadLine());
                    area = 3.14 * rad * rad;
                    break;
                case 2:
                    Console.Write("Please enter Height of Rectangle: ");
                    heightOfRectangle = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter Width of Rectangle: ");
                    widthOfRectangle = Convert.ToInt32(Console.ReadLine());
                    area = widthOfRectangle * heightOfRectangle;
                    break;
                case 3:
                    Console.Write("Please enter Base of Triangle: ");
                    baseOfTriangle = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter height of Triangle: ");
                    heightOfTriangle = Convert.ToInt32(Console.ReadLine());
                    area = .5 * baseOfTriangle * heightOfTriangle;
                    break;
                default:
                    goto Start;
            }
            Console.WriteLine("\nThe area is {0}", area);
            Console.Read();
