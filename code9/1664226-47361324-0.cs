            int value1 = 0;
            int value2 = 0;
            //Populate data
            List<MyDataType> list = new List<MyDataType>();
            for (int i = 1; i < 5; i++)
                list.Add(new MyDataType { SomeProp = i });
            Parallel.For(
                0, //Start of loop
                list.Count, //End of loop
                () => new SomeObject { Number1 = 0, Number2 = 0 }, //Initializer
                (i, loop, subtotal) =>
                {
                    //
                    subtotal.Number1 += Function1(list[i]);
                    subtotal.Number2 += Function2(list[i]);
                    return subtotal;
                }, //Logic
                (x) =>
                {
                    Interlocked.Add(ref value1, x.Number1);
                    Interlocked.Add(ref value2, x.Number2);
                }//Finally
            );
