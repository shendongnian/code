    class SheetContainer : ContainerBase<SheetUnit,SheetContainer> {public SheetContainer(){}}
    class SheetUnit : UnitBase<SheetContainer>
    {
        public CellContainer Cells;
        public PictureContainer Pictures;
        public SheetUnit()
        {
            this.Cells = new CellContainer();
            this.Pictures = new PictureContainer();
        }
    }
    class CellContainer : ContainerBase<CellUnit, CellContainer> { public CellContainer() { } }
    class CellUnit : UnitBase<CellContainer>
    {
        public string ValuePr;//Private Field
        private const string ValuePrDefault = "Default";  
        public string Value//Property for Value
        {
            //All below are Just For Example.
            get
            {
                return this.ValuePr;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    this.ValuePr = ValuePrDefault;
                }
                else
                {
                    this.ValuePr = String.Copy(value);
                }
            }
        }
        public CellUnit()
        {
            this.ValuePr = ValuePrDefault;
        }
    }
    class PictureContainer : ContainerBase<PictureUnit, PictureContainer> { public PictureContainer() { } }
    class PictureUnit : UnitBase<PictureContainer>
    {
        public int[,] Pixels{get;private set;}
        public PictureUnit()
        {
            this.Pixels=new int[,]{{10,20,30},{11,12,13}};
        }
        public int GetSizeX()
        {
            return this.Pixels.GetLength(1);
        }
        public int GetSizeY()
        {
            return this.Pixels.GetLength(0);
        }
        public bool LoadFromFile(string path)
        {
            return false;
        }
    }
    static void Main(string[] args)
        {
            SheetContainer Sheets = new SheetContainer();
            Sheets.Add();
            Sheets.Add();
            Sheets.Add();
            Sheets[0].Pictures.Add();
            Sheets[1].Cells.Add();
            Sheets[2].Pictures.Add();
            Sheets[2].Cells.Add();
            
            Sheets[2].Cells[0].Value = "FirstTest";
            bool res= Sheets[0].Rename("First");//res=true
            res=Sheets[2].Rename("First");//res =false
            int res2 = Sheets.Count;
            res2 = Sheets[2].Pictures[0].Pixels[1, 2];//13
            res2 = Sheets[2].Pictures.Count;//1
            res2 = Sheets[1].Pictures.Count;//0
            res2 = Sheets[0].Pictures[0].GetSizeX();//3
            Console.ReadKey();
        }
