    private A a = new A();
            private void Load()
            {
                a.B.Clear();
                a.Name = string.Empty;
                for (int i = 0; i < 3; i++)
                {
                    var tempB = new B();
                    tempB.Name = string.Empty;
                    for (int j = 0; j < 5; j++)
                    {
                        var tempC = new C();
                        tempC.Name = string.Empty;
                        for (int k = 0; k < 3; k++)
                        {
                            var innerChildB = new B();
                            innerChildB.Name = string.Empty;
                            tempC.B.Add(innerChildB);
                        }
                        tempB.C.Add(tempC);
                    }
                    a.B.Add(tempB);
                }
            }
