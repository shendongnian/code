    int size = 3;  //size of the chunk
    int count = 3; //how many sized chunks will be splitted
    
    int length = input.Length / size;
    int iterate = length < count ? length : count;
    int tailLength = input.Length - iterate * size;
    
    for (int i = 0; i < iterate; i++)
    {
    	sb.Append(input.Substring(i, size));
    	sb.Append(' ');
    }
    
    if (tailLength > 0)
    {
    	sb.Append(input.Substring(size * iterate, tailLength));
    }
