    int id;
    bool idIsNotNumeric = true;
    do
    {
        Console.WriteLine("Please enter your Employee ID: ");
        string idEntered = Console.ReadLine();
        idIsNotNumeric = !int.TryParse(idEntered, out id);
        // other stuff you want to keep doing
               
    } while (idIsNotNumeric || controllerclass.findemployee(id) == null);
    Console.WriteLine("The employee exists");
