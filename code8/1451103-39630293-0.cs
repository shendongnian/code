    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SearchCharInString
    {
        class Program
        {
    
    
    
            #region//Main() Put everything thats finished in here to output it to Console Apllication.
            static void Main(string[] args)
            {
                FirstPart();
            }
            #endregion
    
    
    
            #region // HERE IS WHERE CHANGED HAPPENED!!
            static void FirstPart()
            {
                
                Console.WriteLine(PItoArray());
            }
            #endregion
    
           
    
            #region//PlayerInput() Gets whatever player writes in console apllication 
            static string PlayerInput()
            {
                string S = Console.ReadLine();
    
                return S;
            }
            #endregion
