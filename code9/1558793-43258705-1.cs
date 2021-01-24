    class SomeClass : IHandle<ProjectSignals>
    {
       public void Handle( ProjectSignals signal )
       {
            switch (signal)
            {
                case Connected:
                    break;
            }
        }
    }
