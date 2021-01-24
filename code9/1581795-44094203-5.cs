            AutomapperProfile.Configure();
            var a = new SourceA {A = "Value A"};
            var b = new SourceB() {B = "Value B"};
            var intermediate = new Intermediate() {SourceA = a, SourceB = b};
            var destination = AutoMapper.Mapper.Map<Dest>(intermediate);
            Console.WriteLine(destination.ValueFromSourceA);
            Console.Read();
