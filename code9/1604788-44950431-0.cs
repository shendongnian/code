    listparent.Add(
        new ParentModel
        {
            Id = 1,
            Name = "abc",
            ChildModel = new ChildModel {Number = 2},
            ChildModelList = new List<ChildeModel>(new[]{ 
                                     new ChildModel{Number=1}, 
                                     new ChildModel{Number= xxx}
                                    })
        }
    );
