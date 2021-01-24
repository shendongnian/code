    int total = Y<int, int>(x => y =>
    {
        int price = Items.Where(item => item.Id_Parent == y).Sum(child => x(child.Id));
        return price + Items.First(item => item.Id == y).Price;
    })(3);
