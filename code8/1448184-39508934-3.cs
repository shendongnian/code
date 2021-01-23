    private void dropdown1_SelectedIndexChanged(object sender, EventArgs e){
        List<string> checkedList = new List<string>();
        foreach(checkbox c in dropdown1){
            if(c.Checked){
                checkedList.Add(c.Value/Text/Whatever);
            }
        }
        myTextField.Text = String.Join(",",checkedList);
     }
