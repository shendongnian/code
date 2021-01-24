    int switchRange = 0;
    if(Age >= 17 && Age < 21)
    { switchRange = 1}
    if (Age >= 21 && Age < 28)
    { switchRange = 2}
    if (Age >= 28 && Age < 40)
    { switchRange = 3}
    if (Age >= 40)
    { switchRange = 4}
    
    switch(switchRange)
    {
       case 1:{
    if(SwitchFinal < 20)
    {
    
                            MessageBox.Show("Candidate is Eligible!");
    
                        }
                        else
                        {
                            MessageBox.Show("Candidate is Not Eligible");
                        }
    break;}
    case 2:{
    if(SwitchFinal < 22)
    {
    
                            MessageBox.Show("Candidate is Eligible!");
    
                        }
                        else
                        {
                            MessageBox.Show("Candidate is Not Eligible");
                        }
    break;}
    }
    case 3: case 4:{
    if(SwitchFinal < 24)
    {
    
                            MessageBox.Show("Candidate is Eligible!");
    
                        }
                        else
                        {
                            MessageBox.Show("Candidate is Not Eligible");
                        }
    break;}
