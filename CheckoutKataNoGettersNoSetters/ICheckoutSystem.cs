namespace CheckoutKataNoGettersNoSetters
{
  public interface ICheckoutSystem
  {
    void CurrentItemPriceIs(int price);
    void SpecialOfferOf(int newPrice, int oldPrice);
  }
}