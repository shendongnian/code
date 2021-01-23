    public DateTime ConvertToDateTime(string date)
    {
          DateTime temp;
    
          DateTime.TryParse(date, out temp);
    
          return temp
    }
