    public void CalculateBill()
        {
            TableOrder TO = new TableOrder();
            var tablenumber = TO.TableNumber();
            TO.AddDrink();            
    
            if (tablenumber >= 6 & tablenumber < 10)
            {
                Console.Write("You are due a 10% discount");
    
            }
            if (tablenumber > 10)
            {
                Console.Write("you are due a 15% discount");
            }
    
        }        
    }
