    [HttpPost]
    public String Indexhome( IEnumerable<Seat>  Seats )
    {
         if ((Seats == null) || !Seats.Any(s => s.IsSelected))
         {
                return "you didnt select any seats";
         }
         else
         {
               return "you selected " + string.Join(", ", Seats.Where(s => s.IsSelected).Select(s => s.Name));
         }   
    }
