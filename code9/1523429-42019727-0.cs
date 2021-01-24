    class GetKoord
    {
         GetVertElementasList getList = new GetVertElementasList();
         public void foo()
            {
               var TEST = getList.vertList(vertElementerDgv);
               MessageBox.Show(TEST[5].p2.ToString());
            }
    }
