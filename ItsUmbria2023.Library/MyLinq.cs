using ItsUmbria2023.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsUmbria2023.Library
{
    public static class Linq2
    {
        public static T FirstOrDefault2<T>(this List<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }
        public static IEnumerable<T> Where2<T>(this List<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
    internal class MyLinq
    {
        public Book? FindMyBook(string title, List<Book> books)
        {
            foreach (var x in books)
            {
                if (x.Title == title)
                {
                    return x;
                }
            }
            return default;
        }
        public Book? FindOwner(string owner, List<Book> books)
        {
            foreach (var x in books)
            {
                if (x.Owner == owner)
                {
                    return x;
                }
            }
            return default;
        }
    }
}
