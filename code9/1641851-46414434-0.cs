    try something like
    int passed_index = 0;
    string user_input =  Console.Read(); // Console.ReadKey().KeyChar
    if (int.TryParse(user_input , out passed_index)) {
       if (passed_index < movieList.Count) {
         ; do stuff
       } else {
         ; let user know no items are there
       }
    } else {
       ; ask user to input a number
     }
