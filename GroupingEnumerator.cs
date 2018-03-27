using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class GroupingEnumerator<TKey, TSourse> : IEnumerator<IGrouping<TKey, TSourse>>
    {
        private IEnumerable<TSourse> sourse;
        private Func<TSourse, TKey> keySelector;

        private List<TKey> keyList;
        private IEnumerator<TSourse> enumerator;

        private IGrouping<TKey, TSourse> current;

        public IGrouping<TKey, TSourse> Current
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

        public GroupingEnumerator(IEnumerable<TSourse> sourse, Func<TSourse,TKey> keySelector)
        {
            this.sourse = sourse;
            this.keySelector = keySelector;
            this.keyList = new List<TKey>();
            this.enumerator = this.sourse.GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            TKey key;

            while(this.enumerator.MoveNext())
            {
                key = this.keySelector(this.enumerator.Current);

                if (!this.keyList.Contains(key))
                {
                    this.current = new Group<TKey, TSourse>(key,this.sourse, this.keySelector);
                    this.keyList.Add(key);
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            this.enumerator.Reset();
            this.keyList.Clear();
        }
    }
}
