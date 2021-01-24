    textview.SetTextColor(Color.ParseColor("#787887"));
    string character="Helloworld Developer";
    string withoutspecialcharacter="Helloworld";
    SpannableString spannable = new SpannableString(character);
    spannable.SetSpan(new ForegroundColorSpan(Color.Red), character.IndexOf(withoutspecialcharacter), (character.IndexOf(withoutspecialcharacter)) + (withoutspecialcharacter.Length), SpanTypes.ExclusiveExclusive);
    
    textview.TextFormatted = spannable ;
