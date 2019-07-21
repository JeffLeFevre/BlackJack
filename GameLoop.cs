using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  class GameLoop
  {
    private char _selection = new char();
    private GameState state;
    private List<char> validSelections;
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      StartGame();
    }

    private void StartGame() {
      Console.Clear();
      Console.WriteLine("Welcome to Black Jack!");
      Console.WriteLine();
      Console.WriteLine("Press P to Play");
      validSelections = new List<char> { 'p', 'P' };
      GetUserInput(validSelections);
      Console.Clear();
      Console.WriteLine("Select Starting Chip Value");
      Console.WriteLine("A) 10");
      Console.WriteLine("B) 50");
      Console.WriteLine("C) 100");
      validSelections = new List<char> { 'a', 'A', 'b', 'B', 'c', 'C' };
      GetUserInput(validSelections);

      int startingChipValue;
      switch(_selection) {
        case 'a':
        case 'A':
          startingChipValue = 10;
        case 'b':
        case 'B':
          startingChipValue = 50;
        case 'c':
        case 'C':
          startingChipValue = 100;
        default:
          startingChipValue = 5;
      }
      state = new GameState(startingChipValue);
    }

    private void GetUserInput(List<char> validInputs) {
      bool exitLoop = false;
      Console.WriteLine();
      Console.WriteLine("Press Q to Quit Black Jack");
      do {
        var userInput = Console.ReadKey();
        try {
          _selection = Convert.ToChar(userInput);
          if (_selection == 'q' || _selection == 'Q')
          {
            Environment.Exit(0); 
          }
          if (validInputs.Contains(_selection)){
            exitLoop = true;
          }
        }
        catch(InvalidCastException) {
          continue;
        }
        catch(OverflowException) {
          continue;
        }
      } while (!exitLoop);
      return;
    }

    private void PlayGame() {
      while (!state.gameOver) {
        
      }
    }
    private void GameOver() {
      Console.Clear();
      Console.WriteLine("Do you want to play again? Y/N");
      validSelections = new List<char> { 'n', 'N', 'y', 'Y' };
      GetUserInput(validSelections);
      if(_selection == 'y' || 'Y') {
        state.NextGame();
        PlayGame();
      }
    }
  }
}
