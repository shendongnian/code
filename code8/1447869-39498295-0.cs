    String stringOne="one";
    String stringTwo="two";
    stringOne= stringOne+stringTwo;
    stringTwo = stringOne.substring(0,(stringOne.length()-stringTwo.length())); 
    stringOne = stringOne.substring(stringTwo.length());
