    public void FirstStep()
    {
        //...
    }
    public void SecondStep()
    {
        //...
    }
    public void ThirdStep()
    {
        //...
    }
    public void timer1_tick()
    {
        switch(step)
        {
            case 1:
                FirstStep();
                break;
            case 2:
                SecondStep();
                break;
            case 1:
                ThirdStep();
                break;
        }
    }
