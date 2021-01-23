    sub_reader.ReadToFollowing("NodeA");
    item.NodeA = sub_reader.ReadElementContentAsString();
    
    sub_reader.ReadToFollowing("NodeB");
    item.NodeB = sub_reader.ReadElementContentAsString();
    
    sub_reader.ReadToFollowing("NodeC");
    item.NodeC = sub_reader.ReadElementContentAsString();
