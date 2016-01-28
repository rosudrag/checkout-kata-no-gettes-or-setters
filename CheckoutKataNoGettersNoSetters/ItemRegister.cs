using System.Collections.Generic;

namespace CheckoutKataNoGettersNoSetters
{
  public class ItemRegister : IItemRegister
  {
    private readonly Dictionary<char, int> items;

    public ItemRegister(Dictionary<char, int> items)
    {
      this.items = items;
    }

    public void GiveMeItem(char c, ICheckoutSystem checkoutSystem)
    {
      var price = items[c];

      checkoutSystem.CurrentItemPriceIs(price);
    }
  }
}