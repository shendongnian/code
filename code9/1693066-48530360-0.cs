        IEnumerator Start()
        {
            using (WebClient webClient = new WebClient())
        {
            tabLigneInfos = datacr.RecupTxt(urlArrivee);
            Array.Sort(tabLigneInfos);   
            for (int i = 0; i < tabLigneInfos.Length-2 ;i++)
            {
                tabChampsInfos = tabLigneInfos[i].Split(',');
                txtNompComp.text = tabChampsInfos[1];
                string url = tabChampsInfos[2];
                WWW www = new WWW(url);
                yield return www;
                GameObject AffichCompClone = Instantiate(AffichCompReg, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
                toDestroyList.Add(AffichCompClone);
                alternanceCouleur();
                GameObject infosClone = Instantiate(infos, new Vector3(0, 0, 0), Quaternion.identity,position.transform);
                infosClone.name = "infos0" + i;
                infosNomLien.Add(infosClone.name, tabChampsInfos[2]);
            }
        }
    }
