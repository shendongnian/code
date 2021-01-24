    public void Parse(string Input)
    {
            int data;  
            if(Input!=null)
            {
                foreach(string subString in Input.Split(' '))
                {
                   //call last method
                    last(subString);
                }
            }
     }
