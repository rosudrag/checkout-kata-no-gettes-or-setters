using System;
using System.Collections.Generic;

namespace CheckoutKataNoGettersNoSetters
{
  public class SpecialOffers : ISpecialOffers
  {
    private readonly Dictionary<char, Tuple<int, int>> _specialOfferItems;
    private int counter;
    private Dictionary<char, int> _specialOfferCounter;


    public SpecialOffers(Dictionary<char, Tuple<int, int>> specialOfferItems)
    {
      _specialOfferItems = specialOfferItems;
      GenerateCounter();
    }

    private void GenerateCounter()
    {
      _specialOfferCounter = new Dictionary<char, int>();
      foreach (var specialOfferItem in _specialOfferItems)
      {
        _specialOfferCounter.Add(specialOfferItem.Key, 0);
      }
    }

    public void AddItem(char c, int itemPrice, ICheckoutSystem checkoutSystem)
    {
      foreach (var specialOffer in _specialOfferItems)
      {
        if (specialOffer.Key == c)
        {
          _specialOfferCounter[c] ++;
          var maxHitCount = specialOffer.Value.Item1;
          var maxCountIsHit = _specialOfferCounter[c] == maxHitCount;
          if (maxCountIsHit)
          {
            var newPrice = specialOffer.Value.Item2;
            var oldPrice = itemPrice * maxHitCount;
            checkoutSystem.SpecialOfferOf(newPrice, oldPrice);
            _specialOfferCounter[c] = 0;
          }
        }
      }
    }
  }
}