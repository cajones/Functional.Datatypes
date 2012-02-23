using System.Collections.Generic;

namespace Functional.Datatypes.Specs.MaybeSpecs.ListOf
{
    public class MixedListMaybeContext
    {
        public static void PopulateListWithMixedValues()
        {
            the_list = new[]
                           {
                               Maybe<int>.Nothing,
                               Maybe<int>.Nothing,
                               Maybe.Just(first_integer),
                               Maybe.Just(second_integer)
                           };
        }

        public static int first_integer = 1;
        public static int second_integer = 2;
        
        public static IEnumerable<Maybe<int>> the_list;
    }
}