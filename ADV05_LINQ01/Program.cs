using ADV05_LINQ01.LINQ01;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using static ADV05_LINQ01.LINQ01.ListGenerator;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADV05_LINQ01
{

    internal class customCompareForString : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
           
            if (x == null || y == null) return false;
            return string.Concat(x.OrderBy( c => c)) == string.Concat(y.OrderBy(c=>c));
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            if (obj == null) return 0;  
            return obj.Concat(obj.OrderBy(c=>c)).GetHashCode();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            #region LINQ02
            var products = ProductsList;
            var customers = CustomersList;


            #region LINQ - Element Operators

            #region 1. Get first Product out of Stock
            //var firstOutOfStockProduct = products.First(p => p.UnitsInStock == 0);
            //  Console.WriteLine("First out of stock product:");
            //   Console.WriteLine(firstOutOfStockProduct); 
            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //var re = products.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(re);

            #endregion

            #region 3. Retrieve the second number greater than 5 
            // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            //var res = Arr.Where(n => n > 5).Skip(1).FirstOrDefault();
            //Console.WriteLine(res); 
            #endregion

            #endregion

            #region LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array 
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var OddNumberscount= Arr.Count(n => n % 2 == 1);
            //Console.WriteLine($"Count of Odd Numbers is : {OddNumberscount}"); 
            #endregion

            #region 2. Return a list of customers and how many orders each has.
            //var r = customers.Select(c => new {customerid= c.CustomerID, CountOfOrders=c.Orders.Length });
            //foreach (var item in r)
            //{
            //    Console.WriteLine($"Customer: {item.customerid} has ==> {item.CountOfOrders} orders");
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 3. Return a list of categories and how many products each has
            //var r = products.Select(p => p.Category).ToHashSet();
            //foreach (var item in r)
            //{
            //    var count = products.Count(p => p.Category == item);
            //    Console.WriteLine($"Category: {item}. has ==> {count} products");
            //    Console.WriteLine("---------------------------");
            //}
            #endregion

            #region 4. Get the total of the numbers in an array.
            //int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            //var total = Arr.Sum();
            //Console.WriteLine($"Total of numbers in array is : {total}");

            #endregion


            //string[] strings = File.ReadLines("dictionary_english.txt").ToArray();
            #region  5. Get the total number of characters of all words in dictionary_english.txt
            //var r = strings.Count();
            //Console.WriteLine($"Total number of words in dictionary_english.txt is : {r}"); 
            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt
            //var t = strings.Min()?.Length;
            //Console.WriteLine(t);
            #endregion

            #region 7. Get the length of the longest Word in dictionary_english.txt
            //var LengthOfLongestWord = strings.Max()?.Length;
            //Console.WriteLine(LengthOfLongestWord); 
            #endregion

            #region 8.Get the length of the avarage length word in dictionary_english.txt
            //var AverageLengthOfWords = strings.Average(s => s.Length);
            //Console.WriteLine(AverageLengthOfWords); 
            #endregion

            #region 9  Get the total units in stock for each product category
            //var totalUnitsInStockByCategory = products
            //    .GroupBy(p => p.Category)
            //    .Select(g => new
            //    {
            //        Category = g.Key,
            //        TotalUnitsInStock = g.Sum(p => p.UnitsInStock)
            //    });

            //foreach (var item in totalUnitsInStockByCategory)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //}
            #endregion

            #region 10. Get the cheapest price among each category's products
            //var cheapestPrice = products.GroupBy(p => p.Category)
            //                 .Select( g => new
            //                 {
            //                     Category = g.Key,
            //                     cheapestPrice =  g.Min(p => p.UnitPrice),
            //                 });
            //foreach (var item in cheapestPrice)
            //    {
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //} 
            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let)
            //var df = from p in products
            //         group p by p.Category into g
            //         from p2 in g
            //         let cheapestPrice = g.Min(p => p.UnitPrice)
            //         where p2.UnitPrice == cheapestPrice
            //         select new
            //         {
            //                Category = g.Key,
            //                CheapestPrice = cheapestPrice
            //         };
            //foreach (var item in df)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");

            //} 
            #endregion

            #region 12. Get the most expensive price among each category's products.

            //var maxPrice = products.GroupBy(p => p.Category)
            //                 .Select(g => new
            //                 {
            //                     catg = g.Key,
            //                     price = g.Max(g =>  g.UnitPrice),
            //                 });

            //foreach (var s in maxPrice)
            //{
            //    Console.WriteLine(s);
            //    Console.WriteLine("-------");

            //} 
            #endregion

            #region 13. Get the products with the most expensive price in each category.
            //var dfd = from p in products
            //          group p by p.Category into g
            //          from p2 in g
            //          let maxPrice = g.Max(p => p.UnitPrice)
            //          where p2.UnitPrice == maxPrice
            //          select p2;

            //dfd = products.GroupBy(p => p.Category)
            //    .SelectMany(g => g.Where(p => p.UnitPrice == g.Max(p2 => p2.UnitPrice)));

            //#endregion
            //foreach (var item in dfd)
            //    {
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //










            #endregion

            #region 14 Get the Avarege of the products among each category's products
            //var df = products.GroupBy(p => p.Category)
            //                 .Select(p => new { category = p.Key, average = p.Average(p => p.UnitPrice) });
            //foreach (var item in df)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //} 
            #endregion


            #endregion

            #region LINQ - Set Operators

            #region 1. Find the unique Category names from Product List
            //var uniqueCategoryNames = products.Select(p => p.Category).Distinct();
            //foreach (var item in uniqueCategoryNames)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.
            //var productFirstLetters = products.Select(p => p.ProductName[0]); 
            //var customerFirstLetters = customers.Select(c => c.CompanyName[0]);
            //var uniqueFirstLetters = productFirstLetters.Union(customerFirstLetters);
            //foreach (var item in uniqueFirstLetters)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region 3. Create one sequence that contains the common first letter from both product and customer names.
            //var productFirstLetters = products.Select(p => p.ProductName[0]);
            //var customerFirstLetters = customers.Select(c => c.CompanyName[0]);
            //var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters);
            //foreach (var item in commonFirstLetters)

            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            //var productFirstLetters = products.Select(p => p.ProductName[0]);
            //var customerFirstLetters = customers.Select(c => c.CompanyName[0]);
            //var productOnlyFirstLetters = productFirstLetters.Except(customerFirstLetters);
            //foreach (var item in productOnlyFirstLetters)
            //{
            //    Console.WriteLine(item);

            //}
            #endregion
            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            //var productLastThreeChars = products.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
            //var customerLastThreeChars = customers.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName);
            //var allLastThreeChars = productLastThreeChars.Concat(customerLastThreeChars);
            //foreach (var item in allLastThreeChars)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion



            /*
             * 1. Find the unique Category names from Product List
2. Produce a Sequence containing the unique first letter from both product and customer names.
3. Create one sequence that contains the common first letter from both product and customer names.
4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

             * 
             */

            #endregion

            #region LINQ - Partitioning Operators




            #region 1. Get the first 3 orders from customers in Washington
            //var r = customers.Where(c => c.City == "Washington").SelectMany( o => o.Orders).Take(3);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //} 
            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.
            //var r = customers.Where(c => c.City == "Washington").SelectMany( o => o.Orders).Skip(2).Take(3);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //}  
            #endregion


            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

            //var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var rr =  numbers.TakeWhile((n, index) => n >= index);
            //foreach (var item in rr)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //} 
            #endregion


            #region 4. Get the elements of the array starting from the first element divisible by 3.
            //var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var rrr = numbers.SkipWhile(n => n % 3 != 0);
            //foreach (var item in rrr)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //}
            #endregion



            #region 5. Get the elements of the array starting from the first element less than its position.
            //var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var res = numbers.TakeWhile((n, index) => n >= index);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("-------");
            //} 
            #endregion

            #endregion

            #region LINQ - Quantifiers
            string[] strings = File.ReadLines("dictionary_english.txt").ToArray();

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            //var containsEi = strings.Any(s => s.Contains("ei"));
            //Console.WriteLine(containsEi);
            #endregion


            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            //var r = products.GroupBy(p => p.Category)
            //                .Where(g => g.Any(p => p.UnitsInStock == 0))
            //                .Select(g => new
            //                {
            //                    Category = g.Key,
            //                    Products = g
            //                });

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Category);
            //    foreach (var p in item.Products)
            //    {
            //        Console.WriteLine($"   {p}");
            //    }
            //    Console.WriteLine("-------");
            //}

            #endregion


            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.
            //var r = products.GroupBy(p => p.Category)
            //                 .Where(g => g.All(p => p.UnitsInStock != 0))
            //                 .Select(g => new
            //                 {
            //                     Category = g.Key,
            //                     Products = g
            //                 });

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Category);
            //    foreach (var p in item.Products)
            //    {
            //        Console.WriteLine($"   {p}");
            //    }
            //    Console.WriteLine("-------");
            //} 
            #endregion

            #endregion

            #region LINQ – Grouping Operators

            #region 1 Use group by to partition a list of numbers by their remainder when divided by 5

            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //var r =  numbers.GroupBy(n => n % 5)
            //     .Select(g => new
            //                {
            //                    Remainder = g.Key,
            //                    Numbers = g.ToList()
            //                });
            //foreach (var item in r)
            //{
            //    Console.WriteLine($"number with reminder of {item.Remainder} whene divided by 5");
            //    foreach (var n in item.Numbers)
            //    {
            //        Console.WriteLine($"{n}");
            //    }
            //} 
            #endregion


            #region 2 Uses group by to partition a list of words by their first letter Use dictionary_english.txt for Input

            //var res = strings.GroupBy(s => s[0]);
            //foreach(var i in res)
            //{
            //    Console.WriteLine(i.Key);
            //    Console.WriteLine("------------");
            //    foreach(var item in i)
            //    {
            //        Console.WriteLine($"   {item}");
            //    }
            //    Console.WriteLine("------------");
            //}


            #endregion

            #region 3 Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            //string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
            //var res = Arr.GroupBy(e => string.Concat(e.OrderBy(c => c)));
            //foreach (var i in res)
            //{
            //    Console.WriteLine(i.Key);
            //        Console.WriteLine("------------");

            //    foreach (var item in i)
            //    {
            //        Console.WriteLine($"   {item}");
            //    }
            //        Console.WriteLine("------------");
            //} 
            #endregion


            /*



             */
            #endregion

            #endregion


            #region EF01

            #endregion










        }
    }
}
