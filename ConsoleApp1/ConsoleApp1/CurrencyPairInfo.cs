using System;

namespace ConsoleApp1
{
    public class CurrencyPairInfo
    {
        public Guid Id { get; set; }

        public Currency BaseCurrency { get; set; }
        public Currency QuoteCurrency { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"{BaseCurrency}-{QuoteCurrency}: {Price}";
        }
    }
}