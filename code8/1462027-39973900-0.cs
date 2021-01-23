    try
            {
                Object o = Console.ReadLine();
                double d = double.Parse(o.ToString());
            }
            catch (ArgumentException ex)
            {
                //
            }
            catch (FormatException ex)
            {
                //
            }
            catch (OverflowException ex)
            {
                //
            }
