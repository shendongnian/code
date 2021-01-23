    public static class Dropl 
            {
                public static IEnumerable<SelectListItem> GetDropval(object selectedValue)
                {
                    return new List<SelectListItem>
            {
              
              new SelectListItem{ Text="Japan", Value = "Japan", Selected = "1" == selectedValue.ToString()},
              new SelectListItem{ Text="Jersey", Value = "Jersey", Selected = "2" == selectedValue.ToString()},
              new SelectListItem{ Text="Kazakhstan", Value = "Kazakhstan", Selected = "3" == selectedValue.ToString()},
    
              new SelectListItem{ Text="Russian Federation", Value = "Russian Federation", Selected = "4" == selectedValue.ToString()},
          
    
            };
                }
            }
