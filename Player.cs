namespace BlackJack {
    class Player {
        public bool dealer { get; private set; }
        public bool blackJack { get; private set; }
        public bool bust { get; private set; }
        private List<Card> _hand;
        private int _handPointValue;
        public int chips { get; private set; }

        public int currentBet { get; private set; }

        private int _wins = 0;

        public void Player(bool isDealer, Card initialCardDealt, int startingChipsValue) {
            dealer = isDealer;
            blackJack = false;
            bust = false;
            _hand = new List<Card>();
            _hand.Add(initialCardDealt);
            _handPointValue = initialCardDealt.pointVal;
            chips = startingChipsValue;
            currentBet = 0;
        }

        public int Bet(int betValue) {
            currentBet = betValue;
            if (chips <= 0) {
                currentBet = 0;
                return currentBet;
            }
            if (betValue >= chips) {
                currentBet = chips;
            }
            chips -= currentBet;
            return currentBet;
        }
        public void Hit(Card dealtCard) {
            _hand.Add(dealtCard);
            _handPointValue += dealtCard.pointVal;
            AdjustForAcesAndCheckPoints();
        }

        public string ShowHand() {
            string playerHand;
            foreach(Card playerCard in _hand) {
                playerHand += playerCard.unicodeVal + " ";
            }
            playerHand += "\n";
            return playerHand;
        }

        private void AdjustForAcesAndCheckPoints() {
            if (_handPointValue > CardPointValues.Win) {
                int numAces = _hand.Where(
                    c => c.pointVal == 0
                ).Count();
                if (numAces > 1) {
                    _handPointValue -= ((numAces - 1) * 11);
                }
            }
            CheckAndSetBust();
            if (!bust) {
                CheckAndSetBlackJack();
            }
        }

        private void CheckAndSetBust() {
            if (_handPointValue > CardPointValues.Win) {
                bust = true;
            }
        }

        private void CheckAndSetBlackJack() {
            if (_handPointValue == CardPointValues.Win) {
                blackJack = true;
            }
        }

        private void Win(int chipsWon) {
            chips += chipsWon;
            _wins++;
        }
    }
}