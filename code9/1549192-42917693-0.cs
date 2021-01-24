    Dictionary<int, object> spResult = new Dictionary<int, object>();
    spResult.ToList().ForEach(x =>
            {
                var control = Controls.Cast<Control>().FirstOrDefault(y => y.ID == string.Format("txt_ID{0}", x.Key)) as TextBox;
                if (control != null)
                    control.Text = x.Value.ToString();
            });
        }
