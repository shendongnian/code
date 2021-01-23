    Color c = Color.FromArgb(205,240,248,250);
    string data = TypeDescriptor.GetConverter(typeof(Color)).
                                    ConvertToInvariantString(c);
    Console.WriteLine(data);
    
    Color c2 = (Color)TypeDescriptor.GetConverter(typeof(Color)).
                                    ConvertFromInvariantString(data);
    Console.WriteLine(c2.ToString());
