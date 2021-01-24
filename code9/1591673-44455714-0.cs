    static List<Button> myButtonsList;
    void InitializeButtons() {
        for (int i = 0; i <= 6; i++) {
            Button b = new Button();
            flowLayout.Controls.Add(b);
            myButtonsList.Add(b);
        }
    }
