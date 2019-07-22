namespace BlackJack
{
    /* Concatenating strings from suits + cards gives
       the full unicode code to draw the correct graphic. */ 
    public enum SuitUnicodeValues
    {
      Diamonds = "\u1F0C",
      Spades = "\u1F0A",
      Hearts = "\u1F0B",
      Clubs = "\u1F0D"
    };

    public enum CardUnicodeValues
    {
      Ace = "1",
      Two = "2",
      Three = "3",
      Four = "4",
      Five = "5",
      Six = "6",
      Seven = "7",
      Eight = "8",
      Nine = "9",
      Ten = "A",
      Jack = "B",
      Queen = "C",
      King = "D"
    };

    public enum CardNames
    {
      Ace = "Ace of ",
      Two = "Two of ",
      Three = "Three of ",
      Four = "Four of ",
      Five = "Five of ",
      Six = "Six of ",
      Seven = "Seven of ",
      Eight = "Eight of ",
      Nine = "Nine of ",
      Ten = "Ten of ",
      Jack = "Jack of ",
      Queen = "Queen of ",
      King = "King of "
    };

    public enum SuitNames
    {
      Diamonds = "Diamonds",
      Spades = "Spades",
      Hearts = "Hearts",
      Clubs = "Clubs"
    };

    public enum CardPointValues
    {
        BlackJack = 21,
        Ace = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Jack = 10,
        Queen = 10,
        King = 10
    }
}