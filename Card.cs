namespace BlackJack {
    class Card {
        public string cardName { get; private set; }
        public string unicodeVal { get; private set; }
        public int pointVal {get; private set; }
        public void Card(string suitAndFaceValue, string unicodeValue, int pointValue) {
            cardName = suitAndFaceValue;
            unicodeVal = unicodeValue;
            pointVal = pointValue;
        }
    }
}