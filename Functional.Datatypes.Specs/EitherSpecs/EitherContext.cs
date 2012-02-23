using Machine.Specifications;

namespace Functional.Datatypes.Specs.EitherSpecs
{
    public class EitherContext
    {
        Establish context = () =>
                                {
                                    the_string = "i am the string";
                                    the_int = 69;
                                };

        public static string the_string;
        public static int the_int;
        public static Either<int, string> the_either;
    }
}