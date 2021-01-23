        private bool IsValidAnimal( string answer )
        {
            bool isCapitalized = answer.Length > 0 && Char.IsUpper( answer[0] );
            bool containsOnlyLettersAndSpaces = true;
            foreach( char c in answer )
            {
                if( !Char.IsLetter( c ) && !Char.IsWhiteSpace( c ) )
                {
                    containsOnlyLettersAndSpaces = false;
                    break;
                }
            }
            return isCapitalized && containsOnlyLettersAndSpaces;
        }
