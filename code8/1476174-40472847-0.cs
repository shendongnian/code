laegeInfo laege9 = new laegeInfo()
            {
                yderNr = 09123,
                navn = "Mille Andersen",
                CVR = 05232,
                adresse = "Parkvej 90, Sorø",
                telefon = 22996124,
                email = "MAplo@.dgm",
                kommune = 4180,
              
            };
            laegeInfo laege10 = new laegeInfo()
            {
                yderNr = 10102,
                navn = "Bent Justesen",
                CVR = 00632,
                adresse = "Asgers park 76, Solrød",
                telefon = 99885034,
                email = "BJplo@.dgm",
                kommune = 2680,
            };
            List<laegeInfo> laegers = new List<laegeInfo>(10);
                laegers.Add(laege1);
                laegers.Add(laege2);
                laegers.Add(laege3);
                laegers.Add(laege4);
                laegers.Add(laege5);
                laegers.Add(laege6);
                laegers.Add(laege7);
                laegers.Add(laege8);
                laegers.Add(laege9);
                laegers.Add(laege10);
                var UserInput = int.Parse(txtPraksisoplysningerYderNr.Text);
                var laege = laegers.SingleOrDefault(L => L.yderNr == UserInput);
                if (laege != null)
                    foreach (laegeInfo L in laegers)
                {
                    txtLaegensNavn.Text = L.navn;
                    txtCVR.Text = L.CVR.ToString();
                    txtLaegensAdresse.Text = L.adresse;
                    txtlaegenstlfNR.Text = L.telefon.ToString();
                    txtLaegensEmail.Text = L.email;
                    txtLaegensKommune.Text = L.kommune.ToString();
