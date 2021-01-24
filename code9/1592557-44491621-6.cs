    static void Main(string[] args)
    {
        Ancestor myAncestor = new Ancestor
        {
            Name = "GrandDad",
            Children = new List<Person>
            {
                new Parent
                {
                    Name = "Aunt",
                    Children = new List<Person>
                    {
                        new Child { Name = "Cousin1" },
                        new Parent
                        {
                            Name = "Cousin2",
                            Children = new List<Person>
                            {
                                new Child { Name = "FirstCousinOnceRemoved" }
                            }
                        },
                        new Child { Name = "Cousin3" }
                    }
                },
                new Child { Name = "Uncle" },
                new Parent
                {
                    Name = "Dad",
                    Children = new List<Person>()
                    {
                        new Child { Name = "Me" },
                        new Parent
                        {
                            Name = "Sister",
                            Children = new List<Person>
                            {
                                new Child { Name = "Niece" }
                            }
                        }
                    }
                }
            }
        };
        ShowFamily(myAncestor);
    }
