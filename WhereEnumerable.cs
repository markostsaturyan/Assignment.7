using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class WhereEnumerable<TSourse> : IEnumerable<TSourse>
    {
        private readonly IEnumerable<TSourse> sourse;
        private readonly Func<TSourse, bool> predicate;

        public WhereEnumerable(IEnumerable<TSourse> sourse, Func<TSourse, bool> predicate)
        {
            this.sourse = sourse;
            this.predicate = predicate;
        }

        public IEnumerator<TSourse> GetEnumerator()
        {
            return new WhereEnumerator<TSourse>(this.sourse, this.predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new WhereEnumerator<TSourse>(this.sourse, this.predicate);
        }
    }
}
