    public Customer findCustomer(int id) {
        for (int i = 0; i < Bank.AllCustomers.Count(); i++) {
            if (Bank.AllCustomers.ElementAt(i).Id == id) return Bank.AllCustomers.ElementAt(i);
        }
        return null; //Not found
    }
