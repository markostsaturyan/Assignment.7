using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class WhereEnumerator<TSourse> : IEnumerator<TSourse>
    {
        private readonly Func<TSourse, bool> predicate;

        private IEnumerator<TSourse> sourseEnumerator;

        private TSourse current;

        public TSourse Current
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

        public WhereEnumerator(IEnumerable<TSourse> sourse, Func<TSourse,bool> predicate)
        {
            this.predicate = predicate;
            this.sourseEnumerator = sourse.GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            while (this.sourseEnumerator.MoveNext())
            {
                if (this.predicate(sourseEnumerator.Current))
                {
                    this.current = this.sourseEnumerator.Current;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            this.sourseEnumerator.Reset();
        }
    }
}
