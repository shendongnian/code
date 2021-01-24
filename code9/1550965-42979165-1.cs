            List<Tuple<string,int,string>> list = new List<Tuple<string,int,string>>();
            list.Add(Tuple.Create<string, int, string>("a",100,"up"));
            list.Add(Tuple.Create<string, int, string>("b",99,"up"));
            list.Add(Tuple.Create<string, int, string>("c",120,"up"));
            list.Add(Tuple.Create<string, int, string>("d",200,"up"));
            list.Add(Tuple.Create<string, int, string>("e",112,"down"));
            list.Add(Tuple.Create<string, int, string>("f",10,"down"));
            list.Add(Tuple.Create<string, int, string>("g",110,"down"));
            var temp=list.ToLookup(x => x.Item3);
            var up = temp["up"].OrderByDescending(a => a.Item2);
            Tuple<string, int, string> lowestUp = up.MinBy(a => a.Item2);
            var down=temp["down"].OrderBy(a => a.Item2);
            Tuple<string, int, string> lowestDown = down.MinBy(a => a.Item2);
            if (lowestDown.Item2 < lowestUp.Item2)
            {
                var result = up.Union(down.Except(new Tuple<string, int, string>[] { lowestDown })).ToList();
                result.Insert(result.Count / 2, lowestDown);
            }
            else
            {
                var result = up.Except(new Tuple<string, int, string>[] { lowestUp }).Union(down).ToList();
                result.Insert(result.Count / 2, lowestUp);
            }
