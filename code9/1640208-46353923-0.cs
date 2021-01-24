    var userinput = new DateTime();
    //could use DateTime.Today in place of DateTime.Now depending on situation
    if (userinput > DateTime.Now & userinput < DateTime.Now.AddDays(7))
    {
        //yay the date works
    }
    else
    {
        //boo date doesn't work
    }
