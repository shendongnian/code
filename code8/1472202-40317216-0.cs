            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>())
            {
                var control = editor.Control as IntegerEdit;
                if (control != null)
                {
                        if (editor.Id == "Id" || editor.Caption == "Id")
                        {
                            control.Enabled = false;
                        }           
                }
            }
        
