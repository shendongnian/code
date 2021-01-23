    private void CheckEdit_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
    {
        Console.WriteLine("abn BEFORE modification: "+abn.Count.ToString());
        Console.WriteLine("abn2 BEFORE modification: " + abn2.Count.ToString());
        var cb = sender as DevExpress.Xpf.Editors.CheckEdit;
        byte i = Convert.ToByte(cb.Tag);
        if ((bool)cb.IsChecked)
        {
            a[i].Count += 1;
        }
        else
        {
            a[i].Count -= 1;
        }
        Console.WriteLine("abn AFTER modification: " + abn.Count.ToString());
        Console.WriteLine("abn2 AFTER modification: " + abn2.Count.ToString());
    }
