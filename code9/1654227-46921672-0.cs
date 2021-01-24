    protected void btnAdd_Click(object sender, EventArgs e)
        {
            OtherThing OT = new OtherThing(txtName.Text, Convert.toInt32(txtId.Text);
            TheThing.ThisList.Add(OT);
            this.gridview.DataSource=TheThing.ThisList();
            this.gridview.DataBind();
        }
