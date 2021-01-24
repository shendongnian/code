            protected void SetLangs()
        {
            List<string> sellangs = new List<string>();
            string langs = hfPrgLangs.Value;
            string langtrim = langs.Replace(" ", "");
            sellangs = langtrim.Split(',').ToList<string>();
            foreach (DataListItem dl in dlLanguages.Items)
            {
                Label lblLangName = (dl.FindControl("lblLangName") as Label);
                CheckBox isChk = (dl.FindControl("cbLang") as CheckBox);
                for (int i = 0; i < sellangs.Count; i++)
                {
                    if (sellangs[i].ToString() == lblLangName.Text.ToString())
                    {
                        isChk.Checked = true;
                    }
                }
            }
        }
