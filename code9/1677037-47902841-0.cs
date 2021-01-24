            else
            {
                ToevoegProduct product = new ToevoegProduct();
                product.ProductNaam = textArtikelNaam.Text;
                product.ProductPrijs = Convert.ToInt32(textArtikelPrijs.Text);
                product.ProductBeschrijving = textArtikelOmschrijving.Text;
                product.ProductType = comboBoxType.Text;
                product.ProductAfbeelding = imageArtikel.ImageLocation;
                product.ProductWinkel = 1;
                product.ProductDirectLeverbaar = false; //niet nodig.
                product.ProductKorting = 0;
                product.ProductVoorraad = 1;
                API.postProductMulti("products", product, "toevoegen");
                MessageBox.Show("Product is correct toegevoegd!", "Gelukt!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProductenOverzicht f7 = new ProductenOverzicht();
                Hide();
                f7.Show();
            }
