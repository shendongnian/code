    public void saveData()
        {
            var phBOM = (PlaceHolder)this.Parent.FindControl("phBOM");
            foreach (UserControl ctrl in phBOM.Controls)
            {
                var type = (ucBOM)ctrl;
                var item = ConstructFormData(type);
            }
        }
