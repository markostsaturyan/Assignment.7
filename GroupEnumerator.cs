using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class GroupEnumerator<TKey, TElement>: IEnumerator<TElement>
    {
        private TKey key;
        private Func<TElement, TKey> keySelector;

        private IEnumerator<TElement> enumerator;

        private TElement current;


        public TElement Current
        {
            get
            {
                return this.current;
            }

        }

        object IEnumerator.Current
        {
            get
            {
                return this.current;
            }
        }

        public GroupEnumerator(IEnumerable<TElement> elements, TKey key, Func<TElement, TKey> keySelector )
        {
            this.key = key;
            this.keySelector = keySelector;
            this.enumerator = elements.GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            while(this.enumerator.MoveNext())
            {
                if (this.key.Equals(keySelector(this.enumerator.Current)))
                {
                    this.current = this.enumerator.Current;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            this.enumerator.Reset();
        }
    }
}
