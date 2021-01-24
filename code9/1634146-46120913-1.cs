    var ret = roleDetails.Split(',')
            .Aggregate(seed: new { SBS = new[] { new StringBuilder(), new StringBuilder(),
                                                 new StringBuilder(), new StringBuilder(), },
                                   Start = true },
                    
            func: (seed, role) =>
            {
                var details = role.Split('^');
                if (seed.Start)
                {
                    seed.SBS[0].Append(details[0]);
                    seed.SBS[1].Append(details[1]);
                    seed.SBS[2].Append(details[2]);
                    seed.SBS[3].Append(details[3]);
                    return new
                    {
                        seed.SBS,
                        Start = false,
                    };
                }
                else
                {
                    seed.SBS[0].Append(',').Append(details[0]);
                    seed.SBS[1].Append(',').Append(details[1]);
                    seed.SBS[2].Append(',').Append(details[2]);
                    seed.SBS[3].Append(',').Append(details[3]);
                    return seed;
                }
            },
            resultSelector: result => result.SBS.Select(sb => sb.ToString()).ToArray()
            );
