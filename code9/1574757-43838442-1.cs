    PersianDateTime now = PersianDateTime.Now;
    
    string persianDateTime = now.ToString(); // 1392/03/09 23:37:57
    string persianDate = now.ToString(PersianDateTimeFormat.Date); // 1392/03/09
    string persianFullDateTime = now.ToString("dddd d MMMM yyyy ساعت hh:mm:ss tt"); // پنج شنبه 9 خرداد 1392 ساعت 11:37:57 ب.ظ
    
    TimeSpan persianTime = now.TimeOfDay; // 23:37:57.4641984
