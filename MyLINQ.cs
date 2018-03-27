using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public static class MyLINQ
    {
        public static IEnumerable<TResult> ExtensionSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return new SelectEnumerable<TSource, TResult>(source, selector);
        }

        public static IEnumerable<TSource> ExtensionWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new WhereEnumerable<TSource>(source, predicate);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> ExtensionGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return new GroupingEnumerable<TKey, TSource>(source, keySelector);
        }

        public static IOrderedEnumerable<TSource> ExtensionOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool desceding = false)
        {
            return new OrderByEnumerable<TSource, TKey>(source, keySelector,desceding, Comparer<TKey>.Default);
        }

        public static List<TSource> ExtensionToList<TSource>(this IEnumerable<TSource> source)
        {
            return new List<TSource>(source);
        }

        public static Dictionary<TKey, TSource> ExtensionToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>();

            foreach(var elem in source)
            {
                dictionary.Add(keySelector(elem), elem);
            }
            return dictionary;
        }

    }
}
