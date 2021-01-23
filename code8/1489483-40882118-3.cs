    static void Main(string[] args)
            {
    
                Zones node1 = new Zones()
                {
                    Name = "Root",
                    Id = "1",
                    Children = {
                        new Zones() {
                            Name = "BranchA",
                           Id = "1",
                            Children = {
                                new Zones() {
                                    Name = "Siblings1",
                                     Id = "1",
                                    Children = {
                                        new Zones() {
                                            Name = "subChild1",
                                             Id = "1",
                                            Children = {
                                            }
                                        },
                                        new Zones() {
                                            Name = "subchild2",
                                             Id = "1",
                                            Children= {
                                            }
                                        }
                                    }
    
                                },
                                new Zones() {
                                    Name = "Siblings2",
                                     Id = "1",
                                    Children = {
    
                                    }
                                }
                            }
                        },
                        new Zones() {
                            Name = "BranchB",
                             Id = "1",
                            Children = {
                                new Zones() {
                                    Name = "Sibilings1",
                                     Id = "1",
                                    Children = {
    
                                    }
                                }
                            }
                        }
                    }
                };
                node1.PrintPretty("", true);
    }
