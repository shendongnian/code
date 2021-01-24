            buttonStock.Click += delegate
            {
                stock.RequestFocus(); // this seems to be necessary
                stock.SelectAll(); // this is convenient
                var imm = ((InputMethodManager)GetSystemService(InputMethodService));
                imm.ShowSoftInput(stock, ShowFlags.Forced);
            };
