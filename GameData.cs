using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  class GameData
  {
    /* The purpose of this class is to instantiate
       and track data related to game state. */

    private List<Card> _deck;
    private List<Player> _players; 
    public void GameData(){
      // Instantiate the deck
      _deck = new List<Card>();
      Shuffle();
      // Instantiate dealer
      // Instantiate player
      Deal();
    }

    private void Shuffle() {
      
    }

    private void Deal() {
      // 
    }
  }
}
