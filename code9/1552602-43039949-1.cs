    Button[,] gameButtons = new Button[7,6]; //array of buttons for markers(red and blue)
    bool blue = true; //blue is set to true if the next marker is to be a blue
   
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      this.Text = "Connect 4";
      this.BackColor = Color.BlanchedAlmond;
      this.Width = 500;
      this.Height = 500;
      int x;
      int y;
      for (int row = 0; row < gameButtons.GetLength(0); row++) {
        x = 50 + (row % 7) * 50;
        for (int col = 0; col < gameButtons.GetLength(1); col++) {
          y = 50*col + 50;
          Button newButton = new Button();
          newButton.Location = new System.Drawing.Point(x, y);
          newButton.Name = "btn" + (row + col + 1);
          newButton.Size = new System.Drawing.Size(50, 50);
          newButton.TabIndex = row + col;
          newButton.UseVisualStyleBackColor = true;
          newButton.Visible = true;
          newButton.Click += (sender1, ex) => this.buttonHasBeenPressed(sender1);
          gameButtons[row, col] = newButton;
          Controls.Add(gameButtons[row,col]);
        }
      }
    }
    private void buttonHasBeenPressed(object sender) {
      Button buttonClicked = (Button)sender;
      int col = buttonClicked.Location.X / 50 - 1;
      int targetRow = GetButtonRow(col);
      if (targetRow >= 0) {
        if (blue == true) {
          gameButtons[col, targetRow].BackColor = Color.Red;
        } else {
          gameButtons[col, targetRow].BackColor = Color.Blue;
        }
        blue = !blue;
      }
    }
    public int GetButtonRow(int colIndex) {
      Button curButton;
      for (int row = gameButtons.GetLength(1) - 1; row >= 0; row--) {
        curButton = gameButtons[arrayColIndex, row];
        if (curButton.BackColor != Color.Red && curButton.BackColor != Color.Blue) {
          return row;
        }
      }
      return -1;
    }
  
