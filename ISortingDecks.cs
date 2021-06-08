using System.Collections.Generic;

namespace DeckSorter
{
    public interface ISortingDecks
    {
        void AddDeck(string name);
        void DeleteDeck(string name);
        List<string> GetList();
        void ShuffleDeck(string name, СonfigurationShuffle shuffle);
        Deck GetDeck(string name);
    }
}
