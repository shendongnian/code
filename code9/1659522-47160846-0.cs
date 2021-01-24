        bool isVisible;
        void Button_Click(object sender, System.EventArgs e)
        {
            if(isVisible)
                editText.InputType = Android.Text.InputTypes.TextVariationVisiblePassword;
            else
                editText.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText;
            editText.SetSelection(editText.Text.Length);
            isVisible = !isVisible;
        }
