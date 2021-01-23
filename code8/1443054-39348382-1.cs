                    ComboboxItem item = new ComboboxItem();
                item.Text = _name;
                item.Value = _value;
                list.Add(item);
                
         
            }
            cmbfilter.DataSource = list;
            cmbfilter.SelectedItem = null;
            }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
