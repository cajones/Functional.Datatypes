using System;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeSpecs
{
    [Subject("Given I have two computations that may be or not")]
    public class when_the_first_is_something_and_the_second_is_nothing : context_base
    {
        private Establish context = () =>
                                        {
                                            first = () => { return Maybe.Just(true); };
                                            second = () => { return Maybe<bool>.Nothing; };
                                        };

        private Because of = () => { result = Monad.Both(first, second, Tuple.Create); };

        private It should_not_have_a_value = () => result.HasValue.ShouldBeFalse();
    }

    [Subject("Given I have two computations that may be or not")]
    public class when_the_first_is_nothing_and_the_second_is_something : context_base
    {
        private Establish context = () =>
        {
            first = () => { return Maybe<bool>.Nothing; };
            second = () => { return Maybe.Just(true); };
        };

        private Because of = () => { result = Monad.Both(first, second, Tuple.Create); };

        private It should_not_have_a_value = () => result.HasValue.ShouldBeFalse();
    }

    [Subject("Given I have two computations that may be or not")]
    public class when_the_first_is_something_and_the_second_is_something : context_base
    {
        private Establish context = () =>
        {
            first = () => { return Maybe.Just(true); };
            second = () => { return Maybe.Just(true); };
        };

        private Because of = () => { result = Monad.Both(first, second, Tuple.Create); };

        private It should_have_a_value = () => result.HasValue.ShouldBeTrue();
    }

    public class context_base
    {
        protected static Maybe<Tuple<bool, bool>> result;
        protected static Func<Maybe<bool>> first;
        protected static Func<Maybe<bool>> second;
    }
}
