namespace BillCalc.Library;

public static class BillTools
{
    public static decimal AmountSplit(decimal amount, int people)
    {
        return amount / people;
    }

    public static Dictionary<string, decimal>? TipCalc(
        Dictionary<string, decimal> orders,
        float tip
    )
    {
        if (orders.Count > 0)
        {
            decimal sum = 0;

            sum = orders.Sum(x => x.Value);

            foreach (var order in orders)
            {
                orders[order.Key] = sum * (decimal)tip * order.Value / sum;
            }

            return orders;
        }
        else
            return null;
    }

    public static decimal TipCalc(decimal price, int patron, float tip)
    {
        return price * (decimal)tip / patron;
    }
}
