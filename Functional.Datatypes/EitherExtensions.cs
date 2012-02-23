using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Datatypes
{
    public static class EitherExtensions
    {
        public static IEnumerable<TL> Lefts<TL, TR>(this IEnumerable<Either<TL, TR>> list)
        {
            return list.Select(either => either.LeftValue).CatMaybes();
        }
        public static IEnumerable<TR> Rights<TL, TR>(this IEnumerable<Either<TL, TR>> list)
        {
            return list.Select(either => either.RightValue).CatMaybes();
        }
        public static Tuple<IEnumerable<TL>, IEnumerable<TR>> Partition<TL, TR>(this IEnumerable<Either<TL, TR>> self)
        {
            return new Tuple<IEnumerable<TL>, IEnumerable<TR>>(self.Lefts(), self.Rights());
        }
    }
}
