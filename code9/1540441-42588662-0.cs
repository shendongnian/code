    int counter = 0;
    string line;
    List<string> ColumnHeaders = new List<string>();
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
    new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       String[] listOfChars = line.Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
       
       if(counter <2){
            if(ColumnHeaders.count < listOfChars.count){
                 ColumnHeaders.addRange(listOfChars);
           } 
           else {
              for( i = 0; i<listOfChars.count; i++){
                  ColumnHeaders[i] = ColumnHeaders[i] + listOfChars[i];
               }
           }
        }
        else{
         //run code here to post this line to sql you can use the string split here as well
        }
       counter++;
    }
    file.Close();
