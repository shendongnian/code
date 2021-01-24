    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    var mappedCards = JsonConvert.SerializeObject(new JObject (
      from card in CardListViewModel.CardList
      select new JProperty(card.IndexName, card.CardImage.Src)));
