    string input = "123456789";
    int[] numbersArray = new int[numbers.Length];
    for (int i = 0; i < numbers.Length; i++)
    {                                
         if (Char.IsDigit(numbers[i]))                    
            numbersArray[i] = Int32.Parse(numbers[i].ToString());
 
         Console.Write(numbersArray[i]);              
    }              
     
   
               
            
            
