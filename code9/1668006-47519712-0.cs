    int Id =0;
    bool IsValid = Int32.TryParse(Console.ReadLine(),out Id);
    if(!IsValid)
    {
      throw new CustomExp();
    }
    else
    {
      employee[i].id = Id;
    }
