    btnRecargarInsumos.SuspendLayout();
    btnRecargarInsumos.Visible = true;
    Application.DoEvents();
    btnRecargarInsumos.PerformClick();
    btnRecargarInsumos.Visible = false;
    btnRecargarInsumos.ResumeLayout();
