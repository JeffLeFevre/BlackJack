using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  class GameState
  {
    /* The purpose of this class is to instantiate
       and track data related to game state. */
    private string[] _playerNames;
    private Deck _deck;
    private List<Player> _players;
    private Player _currentPlayer;
    public Player dealer { get; private set; }

    public int chipBettingPool { get; private set; }
    public List<string> winningPlayerNames { get; private set; }

    public bool gameOver { get; private set; }

    public void GameState(int playerStartingChipValue, string[] playerNames){
      _playerNames = playerNames;
      _players = new List<Player>();
      foreach(string name in _playerNames) {
        _players.Add(
          new Player(playerStartingChipValue, name)
        );
      }
      NewGame();
    }

    private void HitPlayer(Player playerToHit, int numCardsToDeal = 1) {
      for(int i = 0; i < numCardsToDeal; i++) {
        playerToHit.Hit(_deck.Draw());
      }
    }
    private void FirstDeal() {
      foreach(Player p in _players) {
        // First round each player is dealt two cards
        _currentPlayer = p;
        HitPlayer(p, 2);
      }
      HitPlayer(dealer, 2);
    }
    private void AddPlayerBetToPool(int betAmount) {
      _currentPlayer.Bet(betAmount);
      chipBettingPool += _currentPlayer.currentBet;
    }
    private void DealRound() {
      foreach(Player p in _players) {
        _currentPlayer = p;
        if(!p.stand) {
          HitPlayer(p);
        }
      }
      HitPlayer(dealer);
    }

    private void CheckWinState() {
      if(dealer.blackJack) {
        PlayerWins(dealer, chipBettingPool);
        return;
      }
      if(dealer.bust) {
        return;
      }
      var winners = _players.Where(p => p.blackJack == true);
      if(winners != null) {
        SplitWinnings(winners);
        return;
      }
    }

    private void SplitWinnings(List<Player> winnerList) {
      // Round down in case the pool doesn't divide evenly.
      // Anything left is lost to the annals of time and tragedy.
      int chipsWonPerPlayer = Convert.ToInt32(Math.Floor(chipBettingPool/winnerList.Count()));
      foreach(Player winner in winnerList) {
        PlayerWins(winner, chipsWonPerPlayer);
      }
    }

    private void PlayerWins(Player winner, int amountOfChipsWon) {
      gameOver = true;
      winner.Win(amountOfChipsWon);
      winningPlayerNames.Add(winner.name);
    }

    public void NewGame() {
      gameOver = false;
      winningPlayerNames = new List<string>();
      _deck = new Deck();
      FirstDeal();
    }
  }
}
