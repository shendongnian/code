        static void Main(string[] args)
        {
            var doc = 
    @"<?xml version=""1.0""?>
    <movement>
    <skill id = ""2"" >
         <cooldown> 5 </cooldown>
     </skill>
     <skill id = ""3"" >
          <cooldown> 10 </cooldown>
      </skill>
    </movement> ";
            var root = XDocument.Parse(doc);
            foreach (var skill in root.Descendants("skill"))
            {
                Console.WriteLine("Skill: {0} \t CoolDOwn: {1}",
                        (int)skill.Attribute("id"),
                        skill.Element("cooldown").Value);
            }
            Console.ReadLine();
        }
