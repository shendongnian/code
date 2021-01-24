        int[] arrayInt = new int[100];
        for (int i = 0; i < arrayInt.Length; i++)
        {
			var input = Console.ReadLine();
			
			if(input.Equals("n")){
				 //for example
                Console.WriteLine("You pressed n");
			}else{
			   
				if(int.TryParse(input, out arrayInt[i])){
					Console.WriteLine("It's a number");
				}else{
					Console.WriteLine("No number and no n!");	
				}
			}
		}
