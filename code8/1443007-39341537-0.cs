    var txts = new[] { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10, txt11, txt12, txt13, txt14 };
    var btns = new[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14 };
    foreach(var txt in txts)
    {
        foreach(var btn in btns)
        {
            if (txt.Text == btn.Text)
            {
                txt.Text = "";
                btn.Visible = true;
                break;
            }
        }
    }
