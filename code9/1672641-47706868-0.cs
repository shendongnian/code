               expression.CreateMap<List<ObjASource>, List<List<MyDto>>>()
                    .ConvertUsing(source =>
                        {
                            return source.Select(list => list.ObjB?.ObjC?.Select(p => new MyDto
                            {
                                field1 = list.field1,
                                field2 = list.field2,
                                field3 = list.field3,
                                field4 = p.fieldX,
                                field5 = p.fieldY
                            })
                            .ToList())
                            .ToList();
                        }
