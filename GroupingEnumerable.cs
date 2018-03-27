using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class GroupingEnumerable<TKey, TSourse> : IEnumerable<IGrouping<TKey, TSourse>>
    {
        private IEnumerable<TSourse> sourse;
        private Func<TSourse, TKey> keySelector;

        public GroupingEnumerable(IEnumerable<TSourse> sourse, Func<TSourse, TKey> keySelector)
        {
            this.sourse = sourse;
            this.keySelector = keySelector;
        }

        public IEnumerator<IGrouping<TKey, TSourse>> GetEnumerator()
        {
            return new GroupingEnumerator<TKey, TSourse>(this.sourse,this.keySelector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupingEnumerator<TKey, TSourse>(this.sourse, this.keySelector);
        }
    }
}
