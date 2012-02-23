using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeSpecs
{
    public class MaybeContext
    {
        Establish context = () =>
                                {
                                    the_object = new object();
                                };

        public static Maybe<object> the_maybe;
        public static object the_object;
        public static object result;
    }

    public class MaybeValueContext : MaybeContext
    {
        Establish context = () =>
        {
            the_maybe = Maybe.Just(the_object);
        };
    }

    public class MaybeNothingContext : MaybeContext
    {
        Establish context = () =>
        {
            the_maybe = Maybe<object>.Nothing;
        };
    }

}