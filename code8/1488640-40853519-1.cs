         string xml = @"<Items>
    <Item>
      <NodeA>Some Value</NodeA>
      <NodeB>N</NodeB>
      <NodeC />
     </Item>
     <Item>
      <NodeA>Some 2223Value</NodeA>
      <NodeB>2223N</NodeB>
      <NodeC>12344</NodeC>
     </Item>
    </Items>";
            XDocument doc = XDocument.Parse(xml);
            var result = doc.Root.Descendants("NodeC");
            
            foreach(var item in result)
            {
                Console.WriteLine(item.Value);
            }
