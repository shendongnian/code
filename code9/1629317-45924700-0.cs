    Services = (from cc in CharityCategories
                                join c in Cao_Categories on cc.CategoryID equals c.CategoryID
                                join chy in CharityYears on cc.CharityYearID equals chy.CharityYearID
                                where chy.CampYearID == 5 && chy.StatusID == 1
                                group c by c.Category into cg
                                select new { Categories = cg.Key.ToString().Trim() }).Aggregate(new StringBuilder(), (a, b) =>
                                {
                                    if (a.Length > 0)
                                        a.Append(",");
                                    a.Append(b.ToString().Split('=')[1].Replace(" }", ""));
                                    return a;
                                }).ToString();
