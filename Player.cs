namespace BlackJack {
    class Player {
        public bool blackJack { get; private set; }
        public bool bust { get; private set; }
        public bool stand { get; private set; }
        public string name { get; private set; }
        private List<Card> _hand;
        private Card _currentCard;
        private int _handPointValue;
        private int _chips;

        public int currentBet { get; private set; }

        private int _wins = 0;

        public void Player(int startingChipsValue, string playerName) {
            blackJack = false;
            bust = false;
            stand = false;
            name = playerName;
            _hand = new List<Card>();
            _chips = startingChipsValue;
            currentBet = 0;
        }

        public void Bet(int betValue) {
            currentBet = betValue;
            if (_chips <= 0) {
                currentBet = 0;
                bust = true;
                Console.WriteLine(name + " is out of chips.");
                return;
            }
            if (betValue >= _chips) {
                currentBet = _chips;
            }
            _chips -= currentBet;
        }
        public void Hit(Card dealtCard) {
            _currentCard = dealtCard;
            _hand.Add(dealtCard);
            _handPointValue += dealtCard.pointVal;
            AdjustForAcesAndCheckPoints();
        }

        public void ShowHand() {
            Console.Write(name + "'s current hand: ");
            foreach(Card playerCard in _hand) {
                playerCard.ShowFace();
            }
            Console.WriteLine();
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
            if (_handPointValue > CardPointValues.BlackJack) {
                bust = true;
            }
        }

        private void CheckAndSetBlackJack() {
            if (_handPointValue == CardPointValues.BlackJack) {
                blackJack = true;
            }
        }

        private void Win(int chipsWon) {
            _chips += chipsWon;
            _wins++;
        }
    }
}