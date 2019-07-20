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
    public void GameData(){
      // Instantiate the deck
      this.Shuffle();
      // Instantiate dealer
      // Instantiate player
      this.Deal();
    }

    private void Shuffle() {
      _deck = new List<Card>{};
    }

    private void Deal() {
      // 
    }
  }
}
