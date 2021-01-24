    string input = "25<10"; //input form your xml
    int operatorPosition;
    //get the position of the operator
    if(input.contains("<")){
      operatorPosition = input.IndexOf("<");
    }else{
      operatorPosition = input.IndexOf(">");
    }
    //maybe i messed up some -1 or +1 here but this should work this
    string x = input.Substring(0,operatorPosition-1);
    string y = input.Substring(operatorPosition+1, input.length-1);
    string z = input.charAt(operatorPosition);
    
    //check if it is < or > 
    if(z.equals("<"){
      //compare x and y with <
      if(Int32.parse(x) < Int32.parse(y)){
        //do something
      }else{
        //do something
      }
    }
    //z does not equal < so it have to be > (if you dont have something like = otherwise you need to check this too)
    else{
      if(Int32.parse(x) < Int32.parse(y)){
        //do something
      }else{
        //do something
      }
