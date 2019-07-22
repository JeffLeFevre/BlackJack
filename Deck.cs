namespace BlackJack {
    class Deck {
        private static Random rnd = new Random();
        private List<Card> _deck;
        private int _cardsLeftOnDeck;
        public void Deck() {
            _deck = new List<Card>();
            CreateDeck();
        }

        private void CreateDeck() {
            foreach (var suitName in SuitNames) {
                foreach (var cardName in CardNames) {
                    var cardTitle = cardName + suitName;
                    var cardUnicode = SuitUnicodeValues[suitName] + CardUnicodeValues[cardName];
                    _deck.Add(
                        new Card(cardTitle, cardUnicode, CardPointValues[cardName])
                    );
                }
            }
            _cardsLeftOnDeck = _deck.Count();
            _deck.Shuffle();
        }

        public Card Draw() {
            Card drawnCard = _deck[_cardsLeftOnDeck--];
            _deck.Remove(card => card.cardName == drawnCard.cardName);
            return drawnCard;
        }

        private static void Shuffle<T>(this IList<T> list)
        {
            for(var i=0; i < list.Count - 1; i++)
                list.Swap(i, rnd.Next(i, list.Count));
        }

        private static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}