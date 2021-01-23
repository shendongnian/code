    bool status = false;
    private void button1_Click(object sender, EventArgs e) {
        if (status != true) {
            status = true;
            System.Diagnostics.Process.Start("C:\\Users\\David\\Desktop\\Test\\Test.exe");
        }
    }
