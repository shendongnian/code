        Button delCaller = sender as Button;
        #region DeltePressedRowDelButton
        Control[] toBeRemovedDelButtons = pnl.Controls.Find($"btnDelete{delCaller.Tag}", true);                   
        foreach (var delBtn in toBeRemovedDelButtons)
        {
            pnl.Controls.Remove(delBtn);
            delBtn.Dispose();
        }
        Control[] toBeRemovedFunctionButtons = pnl.Controls.Find($"btnFunction{delCaller.Tag}", true);
        foreach (var funcBtn in toBeRemovedFunctionButtons)
        {
            pnl.Controls.Remove(funcBtn);
            funcBtn.Dispose();
        }
