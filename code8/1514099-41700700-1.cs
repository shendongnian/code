    var test = JsonConvert.DeserializeObject<RootObject>(json);
    test.data.categories.category.Add(new Category() 
    {
        id = "newId",
        name = "newName",
        color = "newColor",
        description = "new description",
        subcategories = new Subcategories() 
        { 
            subcategory = new List<Subcategory>() 
        }
    });
