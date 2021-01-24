    _btnRecargarInsumos.SuspendLayout();
    _btnRecargarInsumos.Visible = true;
    Application.DoEvents();
    _btnRecargarInsumos.PerformClick();
    _btnRecargarInsumos.Visible = false;
    _btnRecargarInsumos.ResumeLayout();
