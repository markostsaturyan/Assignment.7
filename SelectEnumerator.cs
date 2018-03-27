using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class SelectEnumerator<TSourse, TResult> : IEnumerator<TResult>
    {
        private readonly Func<TSourse, TResult> selector;

        private IEnumerator<TSourse> sourseEnumerator;

        private TResult current;

        public TResult Current
        {
            get
            {
                return current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        public SelectEnumerator(IEnumerable<TSourse> sourse, Func<TSourse,TResult> seletor)
        {
            this.selector = seletor;
            this.sourseEnumerator = sourse.GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (this.sourseEnumerator.MoveNext())
            {
                this.current = selector(this.sourseEnumerator.Current);
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.sourseEnumerator.Reset();
        }
    }
}
