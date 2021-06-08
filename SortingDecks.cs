using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckSorter
{
    public class SortingDecks : ISortingDecks
    {
        private Dictionary<string, Deck> decks;

        public SortingDecks()
        {
            decks = new Dictionary<string, Deck>();
        }

        public void AddDeck(string name)
        {
            if (decks.ContainsKey(name)) throw new Exception();
            decks.Add(name, new Deck());
        }

        public void DeleteDeck(string name)
        {
            if (!decks.ContainsKey(name)) throw new Exception();
            decks.Remove(name);
        }

        public Deck GetDeck(string name)
        {
            if (!decks.ContainsKey(name)) throw new Exception();
            return decks[name];
        }

        public List<string> GetList()
        {
            return decks.Keys.ToList();
        }

        public void ShuffleDeck(string name, СonfigurationShuffle shuffle)
        {
            if (!decks.ContainsKey(name)) throw new Exception();
            decks[name].Shuffle(shuffle);
        }
    }
}
