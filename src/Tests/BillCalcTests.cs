namespace BillCalc.Tests;

[TestFixture]
public class BillCalcTests
{
    [TestCase(100, 2, 100 / 2)]
    [TestCase(310, 5, 310 / 5)]
    [TestCase(520, 10, 520 / 10)]
    public void AmountSplitMethod_ShouldReturnSplitBillAmount_whenGivenAmountAndNumberOfPeople(
        decimal amount,
        int numberOfPeople,
        decimal expected
    )
    {
        decimal result = Library.BillTools.AmountSplit(amount, numberOfPeople);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TipCalcMethod_ShouldReturnTipAmount_whenGivenOneOrderAndTipPercentage()
    {
        Dictionary<string, decimal> orders = new() { { "John", 30.0m } };

        var result = Library.BillTools.TipCalc(orders, 0.5f);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(orders, Has.Count.EqualTo(result!.Count));
        });
    }

    [Test]
    public void TipCalcMethod_ShouldReturnTipAmount_whenGivenThreeOrdersAndTipPercentage()
    {
        Dictionary<string, decimal> orders =
            new()
            {
                { "John", 30.0m },
                { "Mary", 16.9m },
                { "Kate", 41.2m }
            };

        var result = Library.BillTools.TipCalc(orders, 0.3f);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(orders, Has.Count.EqualTo(result!.Count));
        });
    }

    [Test]
    public void TipCalcMethod_ShouldReturnTipAmount_whenGivenSixOrdersAndTipPercentage()
    {
        Dictionary<string, decimal> orders =
            new()
            {
                { "John", 30.0m },
                { "Mary", 16.9m },
                { "Kate", 41.2m },
                { "Huy", 70.9m },
                { "Nasa", 20.9m },
                { "Leo", 9.2m }
            };

        var result = Library.BillTools.TipCalc(orders, 0.3f);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(orders, Has.Count.EqualTo(result!.Count));
        });
    }

    [Test]
    public void TipCalcMethod_ShouldReturnTipAmount_whenGivenZeroOrderAndTipPercentage()
    {
        Dictionary<string, decimal> orders = [];

        var result = Library.BillTools.TipCalc(orders, 0.3f);

        Assert.That(result, Is.Null);
    }

    [TestCase(40, 2, 0.5f, 40 * 0.5 / 2)]
    [TestCase(54, 3, 0.3f, 54 * 0.3 / 3)]
    [TestCase(123, 4, 0.1f, 123 * 0.1 / 4)]
    public void TipCalcMethod_ShouldReturnTipAmount_whenGivenPricePatronsAndTipPercentage(
        decimal price,
        int patron,
        float tip,
        decimal expected
    )
    {
        var result = Library.BillTools.TipCalc(price, patron, tip);

        Assert.That(result, Is.EqualTo(expected));
    }
}
