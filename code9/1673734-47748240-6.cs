        static void Main()
        {
            object a;
            bool flag = true;
            if (flag)
                a = new Test1();
            else
                a = new Test2();
            if (a is Test1)
            {
                ((Test1)a).True_1();        //So, there will be no error anymore
            }
            else
            {
                ((Test2)a).True_2();
            }
        }
