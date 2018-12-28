using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Represents currency key.
    /// </summary>
    public readonly struct Currency : IEquatable<Currency>
    {
        internal Currency(string keyValue)
        {
            KeyValue = keyValue;
        }

        internal bool IsNull => KeyValue == null;

        internal bool IsEmpty => string.IsNullOrEmpty(KeyValue);


        internal string KeyValue { get; }

        /// <summary>Indicate whether two keys are not equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator !=(Currency x, Currency y)
        {
            return !(x == y);
        }

        /// <summary>Indicate whether two keys are not equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator !=(string x, Currency y)
        {
            return !(x == y);
        }

        /// <summary>Indicate whether two keys are not equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator !=(Currency x, string y)
        {
            return !(x == y);
        }

        private static bool CompositeEquals(string keyValue0, string keyValue1)
        {
            return keyValue0.Equals(keyValue1, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>Indicate whether two keys are equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator ==(Currency x, Currency y)
        {
            return CompositeEquals(x.KeyValue, y.KeyValue);
        }

        /// <summary>Indicate whether two keys are equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator ==(string x, Currency y)
        {
            return CompositeEquals(x, y.KeyValue);
        }

        /// <summary>Indicate whether two keys are equal</summary>
        /// <param name="x">The first to compare.</param>
        /// <param name="y">The second to compare.</param>
        public static bool operator ==(Currency x, string y)
        {
            return CompositeEquals(x.KeyValue, y);
        }

        /// <summary>See Object.Equals</summary>
        /// <param name="obj">The <see cref="T:ConsoleApp1.Currency" /> to compare to.</param>
        public override bool Equals(object obj)
        {
            object obj1;
            if ((obj1 = obj) is Currency)
            {
                var currencyKey = (Currency)obj1;
                return CompositeEquals(KeyValue, currencyKey.KeyValue);
            }

            if (obj is string s)
                return CompositeEquals(KeyValue, s);
            return false;
        }

        /// <summary>Indicate whether two keys are equal</summary>
        /// <param name="other">The <see cref="T:ConsoleApp1.Currency" /> to compare to.</param>
        public bool Equals(Currency other)
        {
            return CompositeEquals(KeyValue, other.KeyValue);
        }

        /// <summary>See Object.GetHashCode</summary>
        public override int GetHashCode()
        {
            return KeyValue?.ToUpperInvariant().GetHashCode() ?? 0;
        }

        /// <summary>Obtains a string representation of the key</summary>
        public override string ToString()
        {
            return (string)this ?? "(null)";
        }

        internal void AssertNotNull()
        {
            if (IsNull)
                throw new ArgumentException("A null key is not valid in this context");
        }

        /// <summary>
        ///     Create a <see cref="T:ConsoleApp1.Currency" /> from a <see cref="T:System.String" />.
        /// </summary>
        /// <param name="key">The string to get a key from.</param>
        public static implicit operator Currency(string key)
        {
            if (key == null)
                return new Currency();
            return new Currency(key);
        }

        /// <summary>
        ///     Obtain the key as a <see cref="T:System.String" />.
        /// </summary>
        /// <param name="key">The key to get a string for.</param>
        public static implicit operator string(Currency key)
        {
            switch (key.KeyValue)
            {
                case null:
                    return null;
                case string s:
                    return s;
            }
        }
    }
}