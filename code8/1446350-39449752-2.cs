    case "LastRUEN":
                if (csentry["LAST"].IsPresent)
                {
                    string FIELD_RU = csentry["LAST"].Value;
                    string FIELD_EN;
                    FIELD_EN = Regex.Replace(FIELD_RU, "[Аа]", "a");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Бб]", "b");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Вв]", "v");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Гг]", "h");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Ґґ]", "g");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Дд]", "d");
                    FIELD_EN = Regex.Replace(FIELD_EN , "[Ее]", "e");
                    mventry["lastNameEN"].Value = FIELD_EN;
    }
    break;
