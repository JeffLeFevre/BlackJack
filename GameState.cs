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
    private Random draw = new Random();
    private List<Card> _deck;
    public Card drawnCard;
    private List<Player> _players;

    public int chipBettingPool { get; private set; }

    public bool gameOver { get; private set; }

    public void GameState(int playerStartingChipValue){
      gameOver = false;
      _deck = new List<Card>();
      CreateDeck();
      // According to rules, player gets first draw.
      DrawFromDeck();
      _players.Add(
        new Player(false, drawnCard, playerStartingChipValue)
      );
      DrawFromDeck();
      _players.Add(
        new Player(true, drawnCard, 0)
      );
    }

    private void CreateDeck() {
      foreach (var suit in SuitNames) {
        foreach (var cardName in CardNames) {
          var cardTitle = suit + cardName;
          var cardUnicode = SuitUnicodeValues[suit] + CardUnicodeValues[cardName];
          _deck.Add(
            new Card(cardTitle, cardUnicode, CardPointValues[cardName])
          );
        }
      }
    }

    private void DrawFromDeck() {
      int cardNum = draw.Next(_deck.Count);
      drawnCard = _deck[cardNum];
      _deck.Remove(card => card.cardName == drawnCard.cardName);
    }

    private void CheckAndSetGameOver() {
      foreach(Player p in _players) {
        if(p.bust) {
          if(p.dealer) {
            Console.WriteLine("Dealer Busts!");
          } else {
            Console.WriteLine("Player Busts!");
          }
          if(p.chips <= 0 && !p.dealer) {
            Console.WriteLine("You're out of Chips...Game Over!");
          }
        }
        if(p.blackJack) {
          if(p.dealer) {
            Console.WriteLine("Dealer has Black Jack!");
            p.Win(chipBettingPool);
          }
          Console.WriteLine("Black Jack! You Win!");
          p.Win(chipBettingPool);
        }
        gameOver = true;
      }
    }

    public void NextGame() {
      gameOver = false;
      _deck = new List<Card>();
      CreateDeck();
      foreach(Player p in _players) {
        DrawFromDeck();
        p.Hit(drawnCard);
      }
    }
  }
}
