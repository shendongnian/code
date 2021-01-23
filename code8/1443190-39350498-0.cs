    for (int i = 0; i < 10; i++) {
            if (!CheckifServiceStarted()) {
                DialogResult dlgResult = MessageBox.Show("Service is not Started.Please  start Service to continue", "Start Service", MessageBoxButtons.YesNo);
            if (dlgResult == DialogResult.Yes) {
                for (int j = 0; j < 10; j++)
                    if (!CheckifServiceStarted())
                        Thread.Sleep(1000);
            }
            else {
                System.Environment.Exit(0);
            }
    }
}
