    interface IDated 
    {
      DateTime Date { get; } 
    }
    List<T> GetResultList<T>() where T: IDated
    {
      T x;
      if (x.Date == DateTime.Today); // You can access T.Date
    }
