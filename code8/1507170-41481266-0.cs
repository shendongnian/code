    Button btn = sender as Button;
    switch (btn.Text)
    {
        case "Triangle":
            pnlCircle.Visible = false;
            pnlSquare.Visible = false;
            pnlTriangle.Visible = true;
            break;
        case "Square":
            pnlCircle.Visible = false;
            pnlSquare.Visible = true;
            pnlTriangle.Visible = false;
            break;
        case "Circle":
            pnlCircle.Visible = true;
            pnlSquare.Visible = false;
            pnlTriangle.Visible = false;
            break;
    }
