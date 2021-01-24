    var tb = new TextBlock();
    tb.Inlines.Add(new Run { Foreground = Brushes.Green, Text = 
    principalDB.mensagemRemetente});
    tb.Inlines.Add(" (" + principalDB.mensagemData + ")" + ": " + mensagem);
    LstMensagem.Items.Add(tb);
