    int i = 0;
    while (i != 99)
        try
                    {
                        Write("Enter a number to see the value in that position. Type 99 to stop: ");
                        i = Convert.ToInt32(ReadLine());
                        if(i == 99) {
                          Console.WriteLine("Thanks!!, Breaking here!!!");
                          break;
                        }
                        double arrayVal = array[i];
                        WriteLine("The value at index {0} is {1}", i, arrayVal);
                        ReadLine();
                    }
                    catch (FormatException fe)
                    {
                        throw new FormatException("You did not enter an integer.");
                    }
                    catch (IndexOutOfRangeException ie)
                    {
                        // Show some message here
                    }
    }  
