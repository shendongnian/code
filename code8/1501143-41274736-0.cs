    private void _viewPassword_Click(object sender, EventArgs e) {
        if (_isPasswordHidden) {
            _editText.InputType = 
                Android.Text.InputTypes.TextVariationVisiblePassword 
                | Android.Text.InputTypes.ClassText;
        } else {
            _editText.InputType = 
                 Android.Text.InputTypes.TextVariationPassword 
                 | Android.Text.InputTypes.ClassText;
        }
        _isPasswordHidden = !_isPasswordHidden;
    }
