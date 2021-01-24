    Enum.TryParse(cbOperation.SelectedValue.ToString(), out Operation selectedOperation);
            switch (selectedOperation)
            {
                case Operation.Add:
                    Console.WriteLine("Add operation selected");
                    break;
                case Operation.Subtract:
                    Console.WriteLine("Subtract operation selected");
                    break;
            } 
