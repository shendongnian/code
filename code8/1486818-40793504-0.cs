    var list1 = new List<Person>
    {
        new Person()
        {
            PersonId = 123;
            Name = "Tom";
            Email = "tom@x.com"
        }
    };
    
    var list2 = new List<Person>
    {
        new Person()
        {
            PersonId = 123;
            Name = "Tom";
            Email = "tom@x.com"
        }
    };
    
    var count = list1.count;
    if(list1.count.Equals(list2.count))
    {
        var i;
        for(i=0; i< list1.count; i++)
        {
            if(!list1[i].PersonId.Equals(list2[i]))
            {
                //DO somthing they lists are NOT SAME
                //One of the Person object contain different ID
            }
        }
    }
    else
    {
        //DO somthing, list count is different..
    }
