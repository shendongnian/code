    RectangleModel RM = new RectangleModel(myRectangle); // store this in your class as property;
                int size = 0;
                int.TryParse(q.textBoxNumberOfEmployees.Text, out size);
                if (size > 5 && size < 15)
                {
                    RM.State = new SmallState();                
                }
    
                else if (size > 15 && size < 30)
                {
                    RM.State = new MediumState();
                }
                else if (size > 30 && size < 100)
                {
                    RM.State = new LargeState();
                }
                else
                {
                    RM.State = new NormalState();
                }
