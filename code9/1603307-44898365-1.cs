    var date = DateTime.ParseExact(valuesCsvLine[0], dateFormatString, CultureInfo.InvariantCulture);
                var pass = (valuesCsvLine[1] == "TRUE" ? true : false);
                var cutMark1 = (valuesCsvLine[2] == "TRUE" ? true : false);
                var marks1 = int.Parse(valuesCsvLine[3]);
                var cutMark2 = (valuesCsvLine[4] == "TRUE" ? true : false);
                var marks2 = int.Parse(valuesCsvLine[5]);
                if (pass)
                {
                    if (cutMark1)
                        discharge1Mark1.Add(new Charge
                        {
                            Date = date,
                            Pass = pass,
                            Marks = marks1,
                            CutMark = cutMark1
                        });
                    else
                        discharge1Mark2.Add(new Charge
                        {
                            Date = date,
                            Pass = pass,
                            Marks = marks2,
                            CutMark = cutMark2
                        });
                }else
                {
                    if (cutMark1)
                        charge1Mark1.Add(new Charge
                        {
                            Date = date,
                            Pass = pass,
                            Marks = marks1,
                            CutMark = cutMark1
                        });
                    else
                        charge1Mark2.Add(new Charge
                        {
                            Date = date,
                            Pass = pass,
                            Marks = marks2,
                            CutMark = cutMark2
                        });
                }
