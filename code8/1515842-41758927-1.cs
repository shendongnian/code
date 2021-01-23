        listView1_MouseClick(object sender, MouseEventArgs e)
        {
            getListViewSelected(MyDataType.FromMouseEventArgs(e));
        }
        listView1_KeyDown(object sender, KeyEventArgs e)
        {
            getListViewSelected(MyDataType.FromKeyEventArgs(e));
        }
        private void getListViewSelected(MyDataType data)
        {
            //Do your stuff
        }
