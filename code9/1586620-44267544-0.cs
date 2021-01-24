       public static void ChangeDefaultProperties(Control C)     
       {
            var ControlQueue = new Queue<Control>();
            ControlQueue.Enqueue(C);
            while (ControlQueue.Count > 0)
            {
                Control Current = ControlQueue.Dequeue();
                DefaultPropertiesOverride(Current);
                foreach (Control c in Current.Controls)
                {
                    ControlQueue.Enqueue(c);
                }
            }
        }
        public static void DefaultPropertiesOverride(Control C)
        {
            if(C is DateTimePicker)
            {
                ((DateTimePicker)C).Format = DateTimePickerFormat.Custom;
                ((DateTimePicker)C).CustomFormat = "dd/MM/yyyy";
            }
            if(C is TextBox)
            {
                ((TextBox)C).BackColor = Color.Azure;
            }
        }
