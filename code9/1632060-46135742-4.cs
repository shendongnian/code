    public static class NavigationMenuButtonViewModelHelper
    {
        public static ObservableCollection<NavigationMenuButtonTemplateViewModel> GetNavMenuButtonInfo()
        {
            var data = new ObservableCollection<NavigationMenuButtonTemplateViewModel>();
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/SatSunBonusWhite256x256.png",
                    MenuName = "PRIMAS SABATINAS Y DOMINICALES",
                    BenefitKind = "Subscripción",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/OverTimeMoneyWhite256x256.png",
                    MenuName = "JORNADAS EXTRAORDINARIAS",
                    BenefitKind = "Subscripción",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/VacationBonusWhite256x256.png",
                    MenuName = "PRIMA VACACIONAL",
                    BenefitKind = "Gratuito",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/PecoWhite256x256.png",
                    MenuName = "PERMISOS ECONOMICOS",
                    BenefitKind = "Gratuito",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/PunctualityBonusWhite256x256.png",
                    MenuName = "INCENTIVO PUNTUALIDAD Y ASISTENCIA",
                    BenefitKind = "Gratuito",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/BonForSeniorityWhite256x256.png",
                    MenuName = "BONO DE ANTIGUEDAD",
                    BenefitKind = "Gratuito",
                    Status = "Vigente"
                }));
            AddNavMenuButtonItem(data,
                new NavigationMenuButtonTemplateViewModel(new ButtonInfo
                {
                    Symbol = @"ms-appx:///Assets/AssetsMainMenuPage/WageIncreaseWhite256x256.png",
                    MenuName = "RETROACTIVO SUELDO",
                    BenefitKind = "Gratuito",
                    Status = "Vigente"
                }));
            return data;
        }
        private static void AddNavMenuButtonItem(ObservableCollection<NavigationMenuButtonTemplateViewModel> data, NavigationMenuButtonTemplateViewModel item)
        {
            data.Add(item);
        }
    }
