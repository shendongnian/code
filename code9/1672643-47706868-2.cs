               expression.CreateMap<ObjASource, List<MyDto>>()
                    .ConvertUsing(source =>
                        {
                            return source.ObjB?.ObjC?.Select(p => new MyDto
                            {
                                field1 = source.field1,
                                field2 = source.field2,
                                field3 = source.field3,
                                field4 = p.fieldX,
                                field5 = p.fieldY
                            })
                            .ToList();
                        }
                );
