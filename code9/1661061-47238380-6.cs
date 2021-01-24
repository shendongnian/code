    MCVE.MySampleModel mySampleModel1 = new MCVE.MySampleModel();
    MCVE.MySampleModel mySampleModel2 = new MCVE.MySampleModel();
    ...
    ...
    mySampleModel1.Id = 1;
    mySampleModel1.Name = "X";
    mySampleModel1.Price = 100;
    mySampleModel2.Id = 2;
    mySampleModel2.Name = "Y";
    mySampleModel2.Price = 200;
    this.SomeProperty.Add(mySampleModel1);
    this.SomeProperty.Add(mySampleModel2);
    ...
    ...
