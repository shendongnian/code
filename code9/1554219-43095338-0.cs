    private void Form1_Load(object sender, EventArgs e)
    {
        // Configuring the default style with properties
        // we have common to every lexer style saves time.
        scintilla1.StyleResetDefault();
        scintilla1.Styles[Style.Default].Font = "Consolas";
        scintilla1.Styles[Style.Default].Size = 10;
        scintilla1.StyleClearAll();
        // Configure the CPP (C#) lexer styles
        scintilla1.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
        scintilla1.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintilla1.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
        scintilla1.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
        scintilla1.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
        scintilla1.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
        scintilla1.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
        scintilla1.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla1.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla1.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
        scintilla1.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
        scintilla1.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
        scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        scintilla1.Lexer = Lexer.Cpp;
        // Set the keywords
        scintilla1.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
        scintilla1.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
    }
