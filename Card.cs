namespace BlackJack {
    class Card {
        public string cardName { get; private set; }
        private string _unicodeValue;
        public int pointVal {get; private set; }
        public void Card(string suitAndFaceValue, string unicodeValue, int pointValue) {
            cardName = suitAndFaceValue;
            _unicodeValue = unicodeValue;
            pointVal = pointValue;
        }

        public void ShowFace() {
            Console.Write(_unicodeValue);
        }
    }
}