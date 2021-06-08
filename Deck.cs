using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckSorter
{
    public class Card
    {
        private Suits Suit;
        private Nominal NominalValue;
        
        public Card(Suits suit, Nominal nominal)
        {
            Suit = suit;
            NominalValue = nominal;
        }

        public string GetName()
        {
            return $"{NominalValue} Of {Suit}";
        }
    }

    public class Deck
    {
        const int NumberOfShuffles = 20;

        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();

            for (var nominal = 2; nominal <= 14; nominal++) // (52/4) + 1 = 14
            {
                for (var suit = 0; suit < 4; suit++)
                {
                    Cards.Add(new Card((Suits)suit, (Nominal)nominal));
                }
            }
        }

        private List<Card> ManualShuffle(List<Card> cards, int count, Random random)
        {
            var index = random.Next(cards.Count / 3, cards.Count * 2 / 3);
            var shuffledCards = new List<Card>();

            for (var i = 0; i < cards.Count; i++)
            {
                var card = cards[(index + i) % cards.Count];
                shuffledCards.Add(card);
            }

            if (count == 0)
            {
                return shuffledCards;
            }
            else 
            {
                var residualСards = ManualShuffle(shuffledCards.Take(cards.Count - index).ToList(), count - 1, random);
                return residualСards.Concat(shuffledCards.Skip(cards.Count - index)).ToList();
            }
        }

        public void Shuffle(СonfigurationShuffle shuffle)
        {
            var random = new Random();

            if (shuffle == СonfigurationShuffle.Simple)
            {
                for (var i = 0; i < Cards.Count; i++)
                {
                    var j = random.Next(i + 1);
                    var temp = Cards[j];
                    Cards[j] = Cards[i];
                    Cards[i] = temp;
                }
            }

            if (shuffle == СonfigurationShuffle.Manual)
            {
                for (var i = 0; i < NumberOfShuffles; i++)
                {
                    Cards = ManualShuffle(Cards, 5, random);
                }
            }
        }
    }
}
