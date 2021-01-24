           for (; ; )
                if (!enumerator.MoveNext())
                {
                    if (stack.Count == 0)
                        break; // finished
                               // Depth is decreasing
                    enumerator = stack.Pop();
                    columnIndex--;
                }
                else
                {
                    var currentPerson = enumerator.Current;
                    objectArray[rowIndex, columnIndex] = currentPerson.Name;
                    rowIndex++;
                    if (currentPerson.Children.Any())
                    {
                        // Depth is increasing
                        columnIndex++;
                        stack.Push(enumerator);
                        enumerator = currentPerson.Children.GetEnumerator();
                    }
                }
