using System;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeSpecs
{
    [Subject("Given I'm trying a computation")]
    public class when_it_fails
    {
        private Because of = () => { result = Monad.Try<object>(() => { throw new Exception(); }); };

        private It should_not_have_a_value = () => result.HasValue.ShouldBeFalse();

        private static Maybe<object> result;
    }

    [Subject("Given I'm trying a computation")]
    public class when_it_succeeds
    {
        private Because of = () => { result = Monad.Try(() => new object()); };

        private It should_have_a_value = () => result.HasValue.ShouldBeTrue();

        private static Maybe<object> result;
    }
}
