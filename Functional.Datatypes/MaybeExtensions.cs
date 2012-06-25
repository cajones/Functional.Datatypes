using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Datatypes
{
    public static class MaybeExtensions
    {
        public static Maybe<B> Bind<A, B>(this Maybe<A> self, Func<A, Maybe<B>> binder)
        {
            return self.HasValue
                        ? binder(self.Value)
                        : Maybe<B>.Nothing;
        }
        public static Maybe<B> When<A, B>(this Maybe<A> self, Func<A, Maybe<B>> expression)
        {
            return Bind(self, expression);
        }
        public static Maybe<T> When<T>(this Maybe<T> self, Action<T> action)
        {
            if (self.HasValue)
                action(self.Value);
            return self;
        }
        public static T Failover<T>(this Maybe<T> self, Func<T> action)
        {
            return self.HasValue
                       ? self.Value
                       : action();
        }
        public static T Failover<T>(this Maybe<T> self, T defaultValue)
        {
            return self.HasValue
                       ? self.Value
                       : defaultValue;
        }
        public static IEnumerable<T> CatMaybes<T>(this IEnumerable<Maybe<T>> maybes)
        {
            return maybes.Where(maybe => maybe.HasValue)
                         .Select(maybe => maybe.Value);
        }
        public static IEnumerable<T2> MapMaybes<T1, T2>(this IEnumerable<Maybe<T1>> maybes, Func<T1, T2> map)
        {
            return maybes.CatMaybes().Select(map);
        }
        public static IEnumerable<T> ToList<T>(this Maybe<T> self)
        {
            return self.HasValue
                       ? new[] { self.Value }
                       : new T[] { };
        }
    }
}
