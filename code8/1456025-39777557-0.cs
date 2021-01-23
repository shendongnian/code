            var myControls = this.Controls.Cast<Control>();
            //Gets all the textbox controls on form, you can filter it more by name if you want
            var myTextboxes = myControls.Where(c => c.GetType() == typeof(TextBox));
            var dictValues = new Dictionary<string, string>();
            foreach(var textbox in myTextboxes)
            {
                //Encrypt textbox value
                var encryptedValue = Encrypt(textbox.Text.ToString());
                
                //You can specify what you want for the Key rather than textbox name also.
                dictValues.Add(textbox.Name, encryptedValue);
            }
            var conf = new Configuration("C:\\conf.ini");
            //go through dictionary
            foreach(var item in dictValues)
            {
                //write key and value
                conf.IniWriteValue("Info", item.Key, item.Value);
            }
