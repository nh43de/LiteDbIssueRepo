using System;
using System.Linq;
using LiteDB;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// We're going recreate an issue with wrapped structs here.
        /// We have a struct called "Currency" which is basically a wrapped string.
        /// We will insert into the database, then re-retrieve.
        /// When we do so, we will see that the retrieved value is null.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //get db conn
            var db = new LiteDatabase("test.db");

            //db collection of our class that contains Currency struct properties
            var coll = db.GetCollection<CurrencyPairInfo>();

            //clear all
            coll.Delete(Query.All());

            //create new collection item
            CurrencyPairInfo cpi;
            {
                var cB = new Currency("USD");
                var cQ = new Currency("EUR");

                cpi = new CurrencyPairInfo()
                {
                    BaseCurrency = cB,
                    QuoteCurrency = cQ,
                    Price = 12.0
                };
            }

            //insert into db
            Console.WriteLine("Inserting currency: " + cpi);
            coll.Insert(cpi);
            Console.WriteLine("Done");

            //load back from db
            Console.WriteLine("Loading currency from db");
            var rCpi = coll.FindAll().First();
            Console.WriteLine("Got currency: " + rCpi);

            //you will see that retrieved value for currency properties is (null)

            Console.ReadLine();
        }
    }
}
