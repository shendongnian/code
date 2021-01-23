    <...>
    // Inside Method Body iteration routine...
    <...>
    var instr = mdInfo.Body.Instructions;
                            // Allocate in a new `ListBoxItem` each method and add it to the current listbox with their
                            // ... respective Tag and Content information... // Many Thanks Kao :D
                            newItem = new ListBoxItem();
                            newItem.Content = mdInfo.Name;
                            newItem.Tag = string.Join("\r\n", instr);
                            method.Add(mdInfo);
                            listBox.Items.Add(newItem);
