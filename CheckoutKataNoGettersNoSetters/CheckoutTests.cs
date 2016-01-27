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

    [Test]
    public void Can_Add_Item_A()
    {
      var checkoutSystem = new CheckoutSystem(this);
      checkoutSystem.Scan('A');
      Assert.AreEqual(_priceReported, 50);
    }

    public void ItemScanned(int price)
    {
      this._priceReported = price;
    }
  }

  public interface IScannerListener
  {
    void ItemScanned(int price);
  }

  public class CheckoutSystem
  {
    private readonly IScannerListener _checkoutTests;
    private int _total = 0;

    public CheckoutSystem(IScannerListener checkoutTests)
    {
      _checkoutTests = checkoutTests;
    }

    public void Scan(char c)
    {
      _total += 50;

      _checkoutTests.ItemScanned(_total);
    }
  }
}
