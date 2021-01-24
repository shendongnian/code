            public void searchMUID()
        {
            Muview = (CollectionView)new CollectionViewSource { Source = CRmappings2 }.View; //CRmappings2 is an observable collection and Muview is a public property of collectionview
            //FirstCRSP = AllCRSP;
            //muview.Filter = null;
            Muview.Filter = obj =>
            {
                SPFetchCREntity entity = obj as SPFetchCREntity;
                return obj != null && entity.SW_Version == SearchMU.ToString() && entity.MU_Identifier == Mupass.ToString();
            };
            Muview.Refresh();
        }
