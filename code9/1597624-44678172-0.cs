        using System;
        // ....
        public void Foo()
        {
            // Give the indices of the letters of the string, starting at 0
            Highlight("HELP", "#ffff00ff", 3, 1, 2); 
           // Will output :
           // H<color=#ffff00ff>E</color><color=#ffff00ff>L</color><color=#ffff00ff>P</color>
        }
        
        private string Highlight(string text, string color, params int[] indices)
        {
            Array.Sort(indices);
    
            for (int i = indices.Length - 1 ; i >= 0; i--)
            {
                if( indices[i] == text.Length - 1 )
                    text = String.Format( "{0}<color={1}>{2}</color>", text.Substring(0, indices[i]), color, text[indices[i]] ) ;
                
                else if( indices[i] == 0 )
                    text = String.Format( "<color={0}>{1}</color>{2}", color, text[indices[i]], text.Substring(1));
                
                else if( indices[i] < text.Length )
                    text = String.Format( "{0}<color={1}>{2}</color>{3}", text.Substring(0, indices[i]), color, text[indices[i]], text.Substring(indices[i] + 1));
            }
            
            return text;
        }
