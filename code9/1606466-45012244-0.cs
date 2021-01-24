            bool replaced = false;
            foreach (var x in alphavite)
            {
                if (x.Exists(e => e.EndsWith(letter.ToString())))
                {
                    res.Append(x[1][rnd.Next(0, x[1].Length)]);
                    replaced = true;
                }
            }
            if(!replaced)
                res.Append(letter.ToString());
