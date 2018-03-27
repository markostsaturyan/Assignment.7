using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class Group<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly TKey key;
        private IEnumerable<TElement> elements;
        private Func<TElement, TKey> keySelector;

        public TKey Key
        {
            get
            {
                return this.key;
            }
        }

        public Group(TKey key, IEnumerable<TElement> elements, Func<TElement, TKey> keySelector)
        {
            this.key = key;
            this.elements = elements;
            this.keySelector = keySelector;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return new GroupEnumerator<TKey, TElement>(this.elements, this.key, this.keySelector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupEnumerator<TKey, TElement>(this.elements, this.key, this.keySelector);
        }
    }
}
