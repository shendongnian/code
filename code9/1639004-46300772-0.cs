        public T SetPropertyTypes<T>(bool residential, bool commercial) where T : IPage, new()
        {
            TryClick(residental, propertyTypeResidentialCss, "Residential");
            TryClick(commercial, propertyTypeCommercialCss, "Commercial");
        }
        private void TryClick(bool clickIfNotActive, object propType, string btnName)
        {
            var elem = FindElement(By.CssSelector(propType));
            bool isActive = ElementIsActive(() => elem).Invoke(Driver);
            if (clickIfNotActive && !isActive || isActive)
                ClickButton(() => elem, btnName);
        }
