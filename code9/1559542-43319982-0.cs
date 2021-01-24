    using System;
    using System.Collections.Generic;
    
    public class KeySelector 
    {
        public List<KeyCode> selection;
    
        public void AddKey(KeyCode)
        {
            selection.Add(KeyCode);
        }
    
        public void RemoveKey(KeyCode)
        {
            selection.Remove(KeyCode);
        }
        
        //Foreach Keycode in selection (To make the list that the dev can choose of)
        foreach(Keycode key in selection)
        {
            //TODO write code to make a list
        }
    }
