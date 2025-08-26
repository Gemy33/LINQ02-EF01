using ADV05_LINQ01.ADV05;
using ADV05_LINQ01.LINQ01;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Xml.Linq;
using static ADV05_LINQ01.LINQ01.ListGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADV05_LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ADV05
            //var emp1 = new Employee { EmployeeID = 101, BirthDate = new DateTime(1985, 1, 1), VacationStock = 5 };
            //var emp2 = new Employee { EmployeeID = 102, BirthDate = new DateTime(1940, 1, 1), VacationStock = 10 };
            //var dept = new Department { DeptID = 1, DeptName = "IT" };
            //var club = new Club { ClubID = 1, ClubName = "Chess" };
            //SalesEmployee emp3 = new SalesEmployee { EmployeeID = 201, BirthDate = new DateTime(1990, 1, 1), VacationStock = 15, AchievedTarget=10 };
            //BoardMember boardMember = new BoardMember { EmployeeID = 301, BirthDate = new DateTime(1970, 1, 1), VacationStock = 20 };

            //Console.WriteLine("======================= Before fire the trigger ================");
            //dept.AddStaff(emp1);
            //dept.AddStaff(emp2);
            //club.AddMember(emp1);
            //club.AddMember(emp2);


            //Console.WriteLine("======================= AFter fire the trigger ================");
            //emp3.CheckTarget(3);
            //emp1.VacationStock = -2;



            #endregion

            #region LINQ01
            var products = ProductsList;
            var customers = CustomersList;

            #region LINQ - Restriction Operators
            #region 1. Find all products that are out of stock.
            //var outOfStockProducts = products.Where(p =>p.UnitsInStock == 0);
            //foreach (var item in outOfStockProducts)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            //var ProductsInStockAndCostMoreThan3 = ProductsList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            //foreach (var item in ProductsInStockAndCostMoreThan3)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 3. Returns digits whose name is shorter than their value.
            //         0      1      2       3       4        5      6      7         8        9
            //String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var res= Arr.Select((r,i)=>i).Where( i => Arr[i].Length < i);
            //foreach (var item in res)
            //{
            //    Console.Write($"{item} ");
            //} 
            #endregion
            #endregion

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

            #region LINQ - Ordering Operators

            #region 1. Sort a list of products by name
            //var sortedProducts = products.OrderBy(p => p.ProductName);
            //foreach (var item in sortedProducts)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var sortedWords = Arr.OrderBy(word => word,StringComparer.OrdinalIgnoreCase);
            //foreach (var item in sortedWords)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //} 
            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.
            //var p = products.OrderByDescending(p => p.UnitsInStock);
            //foreach(var item in p)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var r = Arr.OrderBy(word => word.Length).ThenBy(word => word);
            //foreach (var item in r)
            //{
            //    Console.Write($"{item} ");
            //} 
            #endregion

            #region 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var r = Arr.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
            //foreach (var item in r)
            //{   
            //    Console.Write($"{item} ");
            //} 
            #endregion

            #region 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //var r = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            #endregion


            #region 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var r = Arr.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase); 
            #endregion

            #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; 
            //var r = Arr.Where( i => i.Length > 1 && i[1]=='i').Reverse();
            //foreach (var item in r)
            //{
            //    Console.Write($"{item} ");
            //}
            #endregion




            #endregion

            #region LINQ – Transformation Operators
            #region 1. Return a sequence of just the names of a list of products.

            //var productsName= products.Select( p => p.ProductName); 
            #endregion

            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var result= words.Select(p => new { upper = p.ToUpper(), lower=p.ToLower()} ); 
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Upper => {item.upper} || Lower => {item.lower}");
            //    Console.WriteLine("---------------------------");

            //} 
            #endregion

            #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            //var rrr =  products.Select( p => new { price = p.UnitPrice });
            //foreach (var item in rrr)
            //{
            //    Console.WriteLine($"Price => {item}");
            //    Console.WriteLine("---------------------------");
            //} 
            #endregion

            #region 4. Determine if the value of int in an array match their position in the array.

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var rrrr = Arr.Select((v,i) => new {value= v , decsion = v==i});
            //Console.WriteLine("This valus matched your position");
            //Console.WriteLine("Numbers in place");
            //foreach (var item in rrrr)
            //{
            //    Console.WriteLine($"{item.value}: {item.decsion}");
            //}
            #endregion

            #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.



            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var matchNumbers2 = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => (a, b)); // cartesian product
            //Console.WriteLine("pais where a < b");
            //foreach (var item in matchNumbers2)
            //{
            //    Console.WriteLine($"({item.a} is less than {item.b})");
            //    Console.WriteLine("---------------------------");
            //}



            //             
            #endregion

            #region 6.Select all orders where the order total is less than 500.00.
            //var res = customers.SelectMany(c => c.Orders.Where(o => o.Total < 500)); 
            #endregion

            #region 7.Select all orders where the order was made in 1998 or later

            //var res2 = customers.SelectMany(c => c.Orders.Where(o => o.OrderDate.Year >= 1998)); 
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

           
            string[] strings = File.ReadLines("dictionary_english.txt").ToArray();
            #region  5. Get the total number of characters of all words in dictionary_english.txt
            //var r = strings.Count();
            //Console.WriteLine($"Total number of words in dictionary_english.txt is : {r}"); 
            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt
            var t = strings.Min()?.Length;
            Console.WriteLine(t);
            #endregion

            #region 7. Get the length of the longest Word in dictionary_english.txt
            //var LengthOfLongestWord = strings.Max()?.Length;
            //Console.WriteLine(LengthOfLongestWord); 
            #endregion

            #region 8.Get the length of the avarage length word in dictionary_english.txt
            //var AverageLengthOfWords = strings.Average(s => s.Length);
            //Console.WriteLine(AverageLengthOfWords); 
            #endregion

            #endregion

            #endregion











        }
    }
}
