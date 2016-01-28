using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CheckoutKataNoGettersNoSetters
{
  [TestFixture]
  public class CheckoutTests : IScannerListener
  {
    private int _priceReported = 0;
    private Dictionary<char, int> _items = new Dictionary<char, int>()
    {
      {'A', 50},
      {'B', 30},
      {'C', 60 },
      {'D', 99 }
    };

    private Dictionary<char, Tuple<int, int>> _specialOfferItems = new Dictionary<char, Tuple<int, int>>()
    {
      { 'A', new Tuple<int,int>(3, 120)},
      { 'B', new Tuple<int,int>(2, 45)}
    };

    [Test]
    public void Can_Scan_Item_A()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item = 'A';
      checkoutSystem.Scan(item);
      Assert.AreEqual(50, _priceReported);
    }

    [Test]
    public void Can_Scan_Item_B()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item = 'B';
      checkoutSystem.Scan(item);
      Assert.AreEqual(30, _priceReported);
    }

    [Test]
    public void Can_Scan_Multiple_Items()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item1 = 'B';
      var item2 = 'A';
      checkoutSystem.Scan(item1);
      checkoutSystem.Scan(item2);
      Assert.AreEqual(80, _priceReported);
    }

    [Test]
    public void Can_Scan_Item_C_and_D()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item1 = 'C';
      var item2 = 'D';
      checkoutSystem.Scan(item1);
      checkoutSystem.Scan(item2);
      Assert.AreEqual(159, _priceReported);
    }

    [Test]
    public void Can_Scan_SpecialOffer_A()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item = 'A';
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      Assert.AreEqual(120, _priceReported);
    }

    [Test]
    public void Can_Scan_SpecialOffer_B()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item = 'B';
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      Assert.AreEqual(45, _priceReported);
    }

    [Test]
    public void Can_Scan_Item_A_6_Times()
    {
      var itemRegistry = new ItemRegister(_items);
      var specialOffers = new SpecialOffers(_specialOfferItems);
      var checkoutSystem = new CheckoutSystem(this, itemRegistry, specialOffers);
      var item = 'A';
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      checkoutSystem.Scan(item);
      Assert.AreEqual(240, _priceReported);
    }

    public void ItemScanned(int price)
    {
      _priceReported = price;
    }
  }
}
