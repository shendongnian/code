            string value = "";
            sortBox.Invoke(new MethodInvoker(delegate {
                if (sortBox.SelectedIndex != -1)
                {
                    value = sortBox.SelectedItem.ToString();
                }
            }));
            Console.WriteLine("value = " + value);
