using System.Collections.Generic;

namespace Functional.Datatypes.Specs.EitherSpecs.ListOf
{
    public class MixedListEitherContext
    {
        public static void PopulateListWithMixedValues()
        {
            the_list = new[]
                           {
                               Either<int, string>.Right(first_string),
                               Either<int, string>.Left(first_integer),
                               Either<int, string>.Right(second_string),
                               Either<int, string>.Left(second_integer),
                               
                           };
        }

        public static int first_integer = 1;
        public static int second_integer = 2;
        public static string first_string = "a";
        public static string second_string = "b";

        public static IEnumerable<Either<int, string>> the_list;
    }
}