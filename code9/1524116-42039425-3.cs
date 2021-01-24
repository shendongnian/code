    case '7':
        {
            Console.WriteLine("You have chosen to buy : " + System.Environment.NewLine);
            Console.WriteLine(_items[0x31] + "X" + "Cabbages" + System.Environment.NewLine,
                              _items[0x32] + "X" + "Tomatos" + System.Environment.NewLine,
                              _items[0x33] + "X" + "Cheese" + System.Environment.NewLine,
                              _items[0x34] + "X" + "Bread" + System.Environment.NewLine,
                              _items[0x35] + "X" + "Milk" + System.Environment.NewLine,
                              _items[0x36] + "X" + "Onions" + System.Environment.NewLine);
                        Console.WriteLine("Giving a total of" + total + "items");
            // set list to completed:
            action = 0x38;
        }
        break;
    default :
        {
            Console.WriteLine("How many would you like ? ");
            string input = Console.ReadLine();
            int temp = 0;
            if(int.TryParse(input, out temp)) {
                _items[action] += temp;
            }
            action = ChooseAction(menu);
        }
