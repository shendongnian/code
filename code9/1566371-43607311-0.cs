    List<product> c = ListProduct.GetProductList();
           
            List<Bukimedia.PrestaSharp.Entities.AuxEntities.language> lan = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.language>();
            foreach (product p in c)
            {
                lan = p.name;
                foreach (Bukimedia.PrestaSharp.Entities.AuxEntities.language l in lan.Where(l => l.id == 2))
                {
                    {
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: $"http://1234456789@localhost:8080/prestashopdemo/" + p.id_default_image + "-large_default/" + l.Value + ".jpg"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = $"http://localhost:8080/prestashopdemo/index.php?controller=product&id_product="+p.id,
                            Type = "openUrl",
                            Title = "Buy"
                        };
                        cardButtons.Add(plButton);
                        HeroCard plCard = new HeroCard()
                        {
                            Title = l.Value,
                            Subtitle = (p.price.ToString("C")),
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyMessage.Attachments.Add(plAttachment);
                    }
                }
