    public static string Convert(string infix)
        {
            Stack<Operator> OpStack = new Stack<Operator>();
            String Postfix = String.Empty;
            Operator Previous = new Operator('x'),
                     Current = null;
            char[] Ops = { '+', '-', '=', '*', '/' };
            string term = String.Empty;
            foreach (char c in infix)                           //Iterate through char at a time
            {
                if (c == '(')                                   //If open paren
                    OpStack.Push(new Operator(c));              // put on the stack
                else if (c == ')')                              //If close paren
                {
                    Postfix += term + " ";                      //Output the term
                    term = "";                                  // and clear out the term holder
                    Previous = OpStack.Peek();                  //Get a value to know Previous has as real value instead of 'x'
                    while (Previous.ToChar() != '(')             // pop until we reach the open paren
                    {
                        if (OpStack.Count > 0)
                            Current = OpStack.Pop();                //Current becomes what was on top of the stack
                        if(Current.ToChar() != ')' && Current.ToChar() != '(')
                            Postfix += Current.ToChar() + " ";       //  add to output
                        try                                          //Make sure we have more to pop
                        {
                            Previous = OpStack.Pop();                //Previous becomes what was 2nd on the stack
                        }//try
                        catch (Exception)                            //If there's nothing to pop and we're still in this loop
                        {
                            return "Error! Mismatched parentheses!"; //Mismatched or missing parenthesis
                        }//catch
                    }//while
                }//else if
                else if (Ops.Contains(c))                       //If it's an operator
                {
                    Postfix += term + " ";                      //output the term
                    term = "";                                  // and clear the term holder
                    Current = new Operator(c);                  //Assign the current character as Current Op
                    if (OpStack.Count > 0)                      //If there are previous ops in stack
                    {
                        Previous = OpStack.Peek();              // get top op on stack to compare
                        if (Previous.GetPrecedence() > Current.GetPrecedence() && OpStack.Count > 0)            //Decide between > and =
                        {
                            while (Previous.GetPrecedence() > Current.GetPrecedence() && OpStack.Count > 0)       //Pop until we find lesser precedence op
                            {
                                Previous = OpStack.Pop();           //Remove the compared value from stack
                                Postfix += Previous.ToChar() + " "; //Add the popped ops to output
                                if (OpStack.Count > 0)              //make sure we aren't looping too far
                                    Previous = OpStack.Peek();      //assign new value before compare occurs
                            }//while 
                        }//if
                        else if(Previous.GetPrecedence() == Current.GetPrecedence() && OpStack.Count > 0 && Previous.ToChar() != '=')       //Decide between > and =
                        {
                            while (Previous.GetPrecedence() == Current.GetPrecedence() && OpStack.Count > 0 && Previous.ToChar() != '=')    //Pop until = precedence found
                            {
                                Previous = OpStack.Pop();           //Remove the compared value from stack
                                Postfix += Previous.ToChar() + " "; //Add the popped ops to output
                                if (OpStack.Count > 0)              //make sure we aren't looping too far
                                    Previous = OpStack.Peek();      //assign new value before compare occurs
                            }//while
                        }//else if
                        OpStack.Push(Current);                  //Once a <= op is found, store the Current op
                        continue;
                    }//if
                    else                                        //If there are no ops on stack
                        OpStack.Push(Current);                  // store it immediately
                }//else if
                else if (c != ' ')                              //If alphanumeric
                    term += c;                                  // add into term holder
            }//foreach
            Postfix += term + " ";                              //There will be a term left over after the final c, so output it
            while(OpStack.Count > 0)                            //There may also be ops left, so pop them
            {
                Current = OpStack.Pop();
                if (Current.ToChar() == '(' || Current.ToChar() == ')') //If there is a paren remaining
                    return "Error! Mismatched parentheses!";            // it's because of missing complement or misalignment
                Postfix += Current.ToChar() + " ";                      //output the operator
            }//while
            return Postfix;
            }//Convert v2
