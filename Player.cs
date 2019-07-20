namespace BlackJack {
    class Player {
        public bool blackJack;
        private List<Card> _hand;
        private int _money;
        public void Player(Card initialDeal, int startingMoney) {
            this.blackJack = false;
            this._hand.Add(initialDeal);
            this._money = startingMoney;
        }

        public void Hit(Card dealtCard) {
            this.hand.Add(dealtCard);
        }
    }
}