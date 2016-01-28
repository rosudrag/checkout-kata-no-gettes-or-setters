namespace CheckoutKataNoGettersNoSetters
{
  public class CheckoutSystem : ICheckoutSystem
  {
    private readonly IScannerListener _checkoutTests;
    private readonly IItemRegister itemRegister;
    private readonly ISpecialOffers _specialOffers;
    private int _total;
    private int _currentItemPrice;

    public CheckoutSystem(IScannerListener checkoutTests, IItemRegister itemRegister, ISpecialOffers specialOffers)
    {
      _checkoutTests = checkoutTests;
      this.itemRegister = itemRegister;
      _specialOffers = specialOffers;
    }

    public void Scan(char c)
    {
      itemRegister.GiveMeItem(c, this);
      _specialOffers.AddItem(c, _currentItemPrice, this);

      _total += _currentItemPrice;

      _checkoutTests.ItemScanned(_total);
    }

    public void CurrentItemPriceIs(int price)
    {
      _currentItemPrice = price;
    }

    public void SpecialOfferOf(int newPrice, int oldPrice)
    {
      this._total -= oldPrice;
      this._total += newPrice;
    }
  }

  public interface ISpecialOffers
  {
    void AddItem(char c, int itemPrice, ICheckoutSystem checkoutSystem);
  }
}