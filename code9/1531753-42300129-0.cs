    public void MinSaldo(double Money)
            {
                if (MinSaldo < 1000 || saldo - money < MinSaldo )
                {
    
                    throw new Exception("saldo low ");
    
                }
    
                else
                {
                   messagebox.show("works");
                }
            }
