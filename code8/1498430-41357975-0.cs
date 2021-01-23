        protected System.Web.UI.WebControls.Image pic;
        private string colname;
        public MyTemplate(string cName)
        {
            colname = cName;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            pic = new System.Web.UI.WebControls.Image();
            pic.ID = "img_" + colname;\\create an Id for the column(colname is same as DB value for column)
            container.Controls.Add(pic);
        }
