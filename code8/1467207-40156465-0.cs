    public class MyPerson : Person
    {
        public string FirstLast
        { get { return string.Format( "{0} {1}", FirstName, LastName ); }}
    
        public string LastFirst
        { get { return string.Format( "{0}, {1}", LastName, FirstName ); }}
    
        public string YourOtherContext
        { get { return WhateverFunctionToGetContext( this ); }}
    }
