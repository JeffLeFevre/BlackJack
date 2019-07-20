namespace BlackJack {
    class Card {
        private string _suit;
        private string _faceValue;
        private string _unicodeValue;
        public void Card(string suit, string faceValue, string unicodeValue) {
            _suit = suit;
            _faceValue = faceValue;
            _unicodeValue = unicodeValue;
        }
    }
}