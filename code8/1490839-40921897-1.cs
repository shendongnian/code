    private MyEnum sortType;
    private void sortButton_Click(object sender, EventArgs e)
    {
       sortType = (MyEnum)(++((int)sortType) % MyEnum.GetValues().Count());
       switch (sortType)
       {
       }
    }
