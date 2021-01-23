            Button btn = new Button();
            btn.Text = "test";
            btn.OnClientClick = "newbtn_Click()";
        
        [WebMethod]
        public static string newbtnSubmit(string name)
        {
            return name;
        }
