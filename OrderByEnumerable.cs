using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class OrderByEnumerable<TSource,TKey> : IOrderedEnumerable<TSource>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, TKey> keySelector;

        private IComparer<TKey> comparer;

        private List<TSource> orderedList;

        public OrderByEnumerable(IEnumerable<TSource> source,Func<TSource,TKey> keySelector, bool descending, IComparer<TKey> comparer)
        {
            this.source = source;
            this.keySelector = keySelector;
            this.comparer = comparer;
            this.orderedList = new List<TSource>();

            if (descending)
            {
                this.descendingSort();
            }
            else
            {
                this.ascendingSort();
            }

        }

        private void descendingSort()
        {
            IEnumerator<TSource> enumerator = this.source.GetEnumerator();

            TSource current;

            if (enumerator.MoveNext())
            {
                this.orderedList.Add(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    for (int i = 0; i < this.orderedList.Count; i++)
                    {
                        if (this.comparer.Compare(this.keySelector(current), this.keySelector(orderedList[i])) > 0)
                        {
                            this.orderedList.Insert(i, current);
                        }
                    }
                }
            }
        }

        private void ascendingSort()
        {
            IEnumerator<TSource> enumerator = this.source.GetEnumerator();

            TSource current;

            if (enumerator.MoveNext())
            {
                this.orderedList.Add(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    for (int i = 0; i < orderedList.Count; i++)
                    {
                        if (this.comparer.Compare(this.keySelector(current), this.keySelector(this.orderedList[i])) < 0)
                        {
                            this.orderedList.Insert(i, current);
                        }
                    }
                }
            }
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            return new OrderByEnumerable<TSource, TKey1>(this.source, keySelector, descending, comparer);
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return orderedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return orderedList.GetEnumerator();
        }

    }
}
