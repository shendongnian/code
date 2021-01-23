    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace calenderMonth1
    {
        class Program
        {
        int[][] months;
        int day;
        static void Main(string[] args)
        {
            Program calendar = new Program();
            calendar.Months();
            calendar.ColRow();
            calender.DisplayMonth();
        }
        public void Display(int itr)
        {
            for (int i = 0; i < itr; i ++)
            {
                Console.WriteLine();
            }
        }
        public enum MonthNames
        {
            JANUARY, 
            FEBRUARY, 
            MARCH, 
            APRIL, 
            MAY, 
            JUNE, 
            JULY,
            AUGUST, 
            SEPTEMBER,
            OCTOBER,
            NOVEMBER, 
            DECEMBER
        }
        public void Months()
        {
            int month;
            int[] months = new int[12];
            for (int i = 0; i < months.Count(); i ++)
            {
                month = months[i];
                Console.WriteLine(month + "\t");
            }
        }
        public void ColRow()
        {
            months = new int[12][];
            for (int i = 0; i < 12; i ++)
            {
                switch (i)
                {
                    case 0:
                        months[i] = new int[31];
                        break;
                    case 1:
                        months[i] = new int[28];    //This may not always be true...  Leap Year every 4 years
                        break;
                    case 2:
                        months[i] = new int[31];
                        break;
                    case 3:
                        months[i] = new int[30];
                        break;
                    case 4:
                        months[i] = new int[31];
                        break;
                    case 5:
                        months[i] = new int[30];
                        break;
                    case 6:
                        months[i] = new int[31];
                        break;
                    case 7:
                        months[i] = new int[31];
                        break;
                    case 8:
                        months[i] = new int[30];
                        break;
                    case 9:
                        months[i] = new int[31];
                        break;
                    case 10:
                        months[i] = new int[30];
                        break;
                    case 11:
                        months[i] = new int[31];
                        break;
                    default:
                        break;
                }
                    
            }
            int dayInYear = 1;
            for (int thisMonth = 0; thisMonth < months.Count(); thisMonth++)
            {
                for (day = 0; day < months[thisMonth].Count(); day++)
                {
                    months[thisMonth][day] = dayInYear;
                    dayInYear++;
                }
                
            }
            for (int row = 0; row < 12; row ++)
            {
                for (int col =0; col < months[row].Count(); col ++)     //Make sure the array doesn't go out of bounds...
                {
                    switch (row)
                    {
                        case 0:
                            Console.WriteLine(MonthNames.JANUARY.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 1:
                            Console.WriteLine(MonthNames.FEBRUARY.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 2:
                            Console.WriteLine(MonthNames.MARCH.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 3:
                            Console.WriteLine(MonthNames.APRIL.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 4:
                            Console.WriteLine(MonthNames.MAY.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 5:
                            Console.WriteLine(MonthNames.JUNE.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 6:
                            Console.WriteLine(MonthNames.JULY.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 7:
                            Console.WriteLine(MonthNames.AUGUST.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 8:
                            Console.WriteLine(MonthNames.SEPTEMBER.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 9:
                            Console.WriteLine(MonthNames.OCTOBER.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 10:
                            Console.WriteLine(MonthNames.NOVEMBER.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        case 11:
                            Console.WriteLine(MonthNames.DECEMBER.ToString() + "\t" + months[row][col] + "\n");
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
    }
    void DisplayMonth()
    {
            Console.WriteLine("Please insert the numerical value of the month you wish to display:\t");
            int myMonth = Convert.ToInt32(Console.ReadLine());
            myMonth -= 1;
            Console.WriteLine();
            switch (myMonth)
            {
                case 0:
                    for (int col = 0; col < months[myMonth].Count(); col++)
                        Console.WriteLine(MonthNames.JANUARY.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 1:
                    for (int col = 0; col < months[myMonth].Count(); col++)
                        Console.WriteLine(MonthNames.FEBRUARY.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 2:
                    for (int col = 0; col < months[myMonth].Count(); col++)
                        Console.WriteLine(MonthNames.MARCH.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 3:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.APRIL.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 4:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.MAY.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 5:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.JUNE.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 6:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.JULY.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 7:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.AUGUST.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 8:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.SEPTEMBER.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 9:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.OCTOBER.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 10:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.NOVEMBER.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                case 11:
                    for (int col = 0; col < months[myMonth].Count()-1; col++)
                        Console.WriteLine(MonthNames.DECEMBER.ToString() + "\t" + months[myMonth][col] + "\n");
                    break;
                default:
                    break;
            }
        }
    }
