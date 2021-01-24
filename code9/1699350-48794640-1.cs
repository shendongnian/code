    public static bool DoStuff(Parent parent)
    {
                try
                {
                    if (parent is Child1)
                    {
                        Child1 child = parent;
                        DoStuffChild1(child);
                    }
                    else if (parent is Child2)
                    {
                        Child2 child = parent;
                        DoStuffChild2(child);
                    }
                    else if (parent is Child3)
                    {
                        Child3 child = parent;
                        DoStuffChild3(child);
                    }
                }
                catch (Exception)
                {
                    HandleError();
                }
    }
