    using ProductsApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    namespace App.Controllers
    {
        public class CardsController : ApiController
        {
            Card[] cards = new Card[] 
             { 
                new Product { Id = 1, Name = "Card 1"}, 
                new Product { Id = 2, Name = "Card 2"}
            };
            public IEnumerable<Card> GetAllCards()
            {
                return cards;
            }
            public IHttpActionResult GetCardById(int id)
            {
                var card = cards.FirstOrDefault((p) => p.Id == id);
                if (card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }
        }
    }
