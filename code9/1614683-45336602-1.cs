      private static decimal Normalize(decimal value, AngleUnits units)
            {
                decimal normalizedValue;
    
                switch (units)
                {
                    case AngleUnits.Degrees:
                        if (value >= 0 && value <= 360)
                        {
                            normalizedValue = value;
                            return normalizedValue;
                        }
                        else if (value < 0)
                        {
                            value = value + 360;
                            normalizedValue = value;
                            return normalizedValue;
                        }
                        else if (value > 360)
                        {
                            value = value - 360;
                            normalizedValue = value;
                            return normalizedValue;
                        }
                        break;
    
                    default: throw new Exception("no Angleunits match was found");  
                          
                       
    
    
    
    
                }
                return value; 
                
    
            }
