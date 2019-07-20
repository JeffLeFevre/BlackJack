using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  class GameLoop
  {
    /* The loop's purpose is executing business logic.
       It will instantiate objects pertaining to
       game data and change state. */
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      StartGame();
    }

    private void StartGame() {
      // Set up the game
    }

    private void CheckState() {
      // Check for end game scenario
    }
    private void GameOver() {
      // Put a bow on it and wrap it up
    }
  }
}
