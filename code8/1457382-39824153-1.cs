        while (moreData != "N")
            {
                Console.Write("Enter Last Name: ");
                inValue = Console.ReadLine();
                lastName[nameCnt] = Convert.ToString(inValue);
                nameCnt++;
                Console.Write("Keep going Y/N? ");
                moreData = Console.ReadLine().ToUpper();
            }
