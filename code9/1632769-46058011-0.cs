    CustomerClassLibrary.Customer C =  new CustomerClassLibrary.Customer();              
    C.FirstName = "John";
    C.LastName = "TEST";
    string returnString =ss.GetAllTickets(C);
    Console.WriteLine(returnString); 
