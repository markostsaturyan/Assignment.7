using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtension
{
    public class SelectEnumerable<TSourse, TResult> : IEnumerable<TResult>
    {
        private readonly IEnumerable<TSourse> sourse;
        private readonly Func<TSourse, TResult> selector;

        public SelectEnumerable(IEnumerable<TSourse> sourse,Func<TSourse, TResult> selector)
        {
            this.sourse = sourse;
            this.selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new SelectEnumerator<TSourse, TResult>(this.sourse, this.selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SelectEnumerator<TSourse, TResult>(this.sourse, this.selector);
        }
    }
}
