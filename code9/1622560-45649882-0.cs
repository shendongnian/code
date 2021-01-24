        string[] backPack = new string[5];
        int lastIndex = 0;
        int addItem(string[] myList, int index) {
            while (index < myList.Length) {
                    Console.Write("Vad vill du lägga till? "); // What do you want to add.
                    myList[index] = Console.ReadLine();
                    index += 1;
                    Console.Write("Vill du lägga till fler produkter i din ryggsäck?(j/n): "); //(Do you want to add more items to the backpack?
                    answer = Console.ReadLine().ToLower();
                    if (answer == "n") {
                        break;
                    }
              }
              return index;
        }
    // Now you can call lastIndex = addItem(backPack, lastIndex) at each time you want to add a new item
