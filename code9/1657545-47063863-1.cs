        public class Option
        {
            public string Name { get; set; }
            /// <summary>
            /// Used to treat the sub options as seperate properties rather than 
            /// options for this property.
            /// </summary>
            public bool IsCategory { get; set; }
            /// <summary>
            /// Lists of available options for this property, or sub properties
            /// for this property if `IsCategory` is true.
            /// </summary>
            public List<Option> Options { get; set; }
            /// <summary>
            /// If `IsCategory` is false, indicates the selected option for this property.
            /// </summary>
            public Option SelectedOption { get; set; }
            public Option(string name, bool isCategory)
            {
                Name = name;
                IsCategory = isCategory;
                Options = new List<Options>();
            }
        }
        public void Example()
        {
            Option pipes = new Option("Pipes", true);
            Option material = new Option("Material", false);
            Option size= new Option("Size", false);
            Option blackSteel = new Option("Black Steel", true);
            Option stainlessSteel = new Option("Stainless Steel", true);
            Option schedule = new Option("Schedule", false);
            schedule.Options.Add(new Option("10", false));
            schedule.Options.Add(new Option("20", false));
            schedule.Options.Add(new Option("40", false));
            schedule.Options.Add(new Option("80", false));
            blackSteel.Options.Add(schedule);
            stainlessSteel.Options.Add(schedule);
            material.Options.Add(blackSteel);
            material.Options.Add(stainlessSteel);
            pipes.Options.Add(material);
            pipes.Options.Add(size);
        }
