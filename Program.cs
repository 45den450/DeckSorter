using System;

namespace DeckSorter
{
    class Program
    {
        public static void PrintDeck(SortingDecks sortingDeck, string name)
        {
            var cards = sortingDeck.GetDeck(name).Cards;
            foreach (var card in cards)
            {
                Console.WriteLine(card.GetName());
            }
        }

        static void Main(string[] args)
        {
            var sortingOfDeck = new SortingDecks();
            sortingOfDeck.AddDeck("1");
            sortingOfDeck.AddDeck("2");

            PrintDeck(sortingOfDeck, "1");

            Console.WriteLine("-----------------");

            sortingOfDeck.ShuffleDeck("1", СonfigurationShuffle.Simple);
            PrintDeck(sortingOfDeck, "1");

            Console.WriteLine("-----------------");

            sortingOfDeck.ShuffleDeck("2", СonfigurationShuffle.Manual);
            PrintDeck(sortingOfDeck, "2");
        }
    }
}
