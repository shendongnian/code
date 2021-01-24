    public class SpecificHandler : IHandler
    {
        ....
        public event Handler.Actiontriggered Actiontriggered
        {
            add
            {
                this.handler.Actiontriggered+= value; // handler is the same as in the snippet above
            }
    
            remove
            {
                this.handler.Actiontriggered-= value;
            }
        }
    }
