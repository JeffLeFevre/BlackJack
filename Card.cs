namespace BlackJack {
    class Card {
        public string cardName { get; private set; }
        public string unicodeValue { get; private set; }
        public int pointValue {get; private set; }
        public void Card(string suitAndValueString, string unicodeValue, int pointValue) {
            cardName = suitAndValueString;
        }
    }
}