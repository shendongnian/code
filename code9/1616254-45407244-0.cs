    do{
    var temp=0; ///Temporary variable to check the result count
    //intially variable b will be zero because INtially result count is zero
    
      Console.WriteLine(" Please Choose one of the options:");
            Console.WriteLine("1> Search by first name");
            Console.WriteLine("2> Search by date of birth");
            switch ( Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("You choose:1");
                    Console.WriteLine("Type your first name:");
                    var a = Console.ReadLine();
    
                    var case1 = students.Where(x=>x.FirstName==a);
                       temp=case1.Count();    //Getting result count in another variable
                    if (case1.Count()!=0)
                    {
                        Console.WriteLine("Found! Here are the details:");
                        foreach (var x in case1)
                        {
                            Console.WriteLine("Name: {0}{1} D.O.B:{2} and Gender{3}", x.FirstName, x.Lastname, x.DOB, x.Gender);
                        }
    
    
                    }
                    else
                    {
                        Console.WriteLine(" Enter the correct information");
    
                    }
                    break;
    
                case 2:
                    Console.WriteLine("You choose:2");
                    Console.WriteLine("Enter your Date of Birth in format MM/DD/YYYY:");
    
                    var b = DateTime.Parse(Console.ReadLine());
                    //Console.WriteLine(b);
                    //Console.ReadLine();
    
                        
    var case2 = students.Where(x => x.DOB == b);
    temp=case2.Count();    //Getting result count in another variable
                    if (case2.Count() != 0)
                    {
                        Console.WriteLine("Found! Here are your details");
                        foreach (var x in case2)
                        {
                            Console.WriteLine("Name:{0} {1} DOB:{2} Gender:{3}", x.FirstName, x.Lastname, x.DOB, x.Gender);
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Enter the correct information");
    
                    } 
                    break;
                    default:
                    Console.WriteLine("Please enter the valid option");
                    break;
    
            }
    }while(temp==0);   ////Endless Loop while result is zero
