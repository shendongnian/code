    string myinput = "abc123$%";
    			int letter =0 , digit = 0, specialCharacter = 0;
    			myinput.ToCharArray().ToList().ForEach(x =>
    			{
    				letter = Char.IsLetter(x) ? ++letter : letter;
    				digit = Char.IsDigit(x) ? ++digit : digit;
    				specialCharacter = !Char.IsLetterOrDigit(x) ? 
                                      ++specialCharacter : specialCharacter;
    			});
    			string formattedVal = String.Format("A{0}D{1}S{2}", letter, digit, 
                                                           specialCharacter);
