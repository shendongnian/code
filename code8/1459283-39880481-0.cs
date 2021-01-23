            var dictonary = new Dictionary<CMD, List<string>>();
            var names = Enum.GetNames(typeof(CMD));
            foreach (var name in names)
            {
                var value = (CMD)Enum.Parse(typeof(CMD), name);
                if(!dictonary.ContainsKey(value))
                    dictonary.Add(value, new List<string>() {name});
                else
                    dictonary[value].Add(name);
            }
