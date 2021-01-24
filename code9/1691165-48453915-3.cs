    int CalculatePrice(int id)
    {
        int price = Items.Where(item => item.Id_Parent == id).Sum(child => CalculatePrice(child.Id));
        return price + Items.First(item => item.Id == id).Price;
    }
    int total = CalculatePrice(3); // 3 is just an example id
