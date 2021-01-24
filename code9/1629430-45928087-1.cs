    var tb = new TextBlock();
    tb.Inlines.Add(new Run { Background= Brushes.Green, Text = 
    principalDB.mensagemRemetente});
    tb.Inlines.Add(" (" + principalDB.mensagemData + ")" + ": " + mensagem);
    LstMensagem.Items.Add(tb);
