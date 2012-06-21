using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional.Datatypes
{
    public static class Monad
    {
        public static Maybe<T> Try<T>(Func<T> expression)
        {
            try
            {
                return Maybe.Just(expression());
            }
            catch
            {
                return Maybe<T>.Nothing;
            }
        }

        public static Maybe<T3> Both<T1, T2, T3>(Func<Maybe<T1>> first, Func<Maybe<T2>> second, Func<T1, T2, T3> binder)
        {
            return first().Bind(firstResult => second().Bind(secondResult => Maybe.Just(binder(firstResult, secondResult))));
        }
    }
}
