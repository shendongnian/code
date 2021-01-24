            var test = new List<ObjASource>
            {
                new ObjASource
                {
                    field1 = "1",
                    field2 = "2",
                    field3 = "3",
                    ObjB = new ObjB
                    {
                        ObjC = new List<ObjC>
                        {
                            new ObjC
                            {
                                fieldX = "X",
                                fieldY = "Y"
                            }
                        }
                    }
                }
            };
            var result = Mapper.Map<List<List<MyDto>>>(test);
