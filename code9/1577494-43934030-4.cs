    void UpdateStatus(BoardStatus status)
    {
        var color = status.token.IsMarked() ? Color.Blue : Color.Black;
        var label = new Label
                    {
                        Text = token.GetNbr().ToString(),
                        ForeColor = color;
                    };
        tableLayoutPanel1.Controls.Add(label, status.column, status.line);
    }
    public async void Start_Click(object sender, EventArgs args)
    {
        TotalStatusLabel.Text="Starting";
        var progress=new Progress<TokenProgress>(UpdateStatus);
        //Run in the background without blocking
        await Task.Run(()=>Solve(progress));
        //We are back in the UI
        TotalStatusLabel.Text="Finished";
    }
    private void Solve(IProgress<TokenStatus> progress)
    {
        SudokuGameBoard sudokuGameBoard = new SudokuGameBoard(progress);
        Sudoku sudoku = new Sudoku();
        sudoku.Load(sudokuGameBoard);
        sudoku.FindSolution(sudokuGameBoard, 0);
    }
