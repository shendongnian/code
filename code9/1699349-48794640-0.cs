    public static bool DoStuff(Parent parent)
            {
                try
                {
                    if (parent is Child1)
                    {
                        Child1 child = parent as Child1;
                        DoStuffChild1(child);
                    }
                    else if (parent is Child2)
                    {
                        Child2 child = parent as Child2;
                        DoStuffChild2(child);
                    }
                    else if (parent is Child3)
                    {
                        Child3 child = parent as Child3;
                        DoStuffChild3(child);
                    }
                }
                catch (Exception)
                {
                    HandleError();
                }
            }
