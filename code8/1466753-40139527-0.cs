    <script runat="server">
        void Button2_Click(object sender, EventArgs e) //this method should be moved to code behind
        {
            var solarvalue = int.Parse(txtSolarValue.Text); //really need some error handling here in case it's not a valid number
    
            if (solarvalue > 0)
            {
                try
                {
                    SendMail();                              
                }
                catch (Exception) { } //do not do empty catch blocks! Log the exception!
            }
        }
    </script>
