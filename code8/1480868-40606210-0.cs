            string value = @"...<h3>Title1</h3> ......<h3>Title2</h3> ......<h3>Title3</h3> ...";
            List<string> ListOfTags = new List<string>();
            string[] split1 = value.Split(new string[] { "<h3>" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in split1.Skip(1))
            {
                string[] split2 = item.Split(new string[] { "</h3>" }, StringSplitOptions.RemoveEmptyEntries);
                ListOfTags.Add(split2[0]);
            }
            var result = String.Join(", ", ListOfTags.ToArray());
            Console.WriteLine(result);
            //Output => Title1, Title2, Title3
