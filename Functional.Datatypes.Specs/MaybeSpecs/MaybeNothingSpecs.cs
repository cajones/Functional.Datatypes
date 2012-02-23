using System;
using Functional.Datatypes.Specs.MaybeSpecs;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeNothingSpecs
{
    [Subject("Given a maybe with nothing")]
    public class when_it_is_nothing : MaybeContext
    {
        Because of = () => { the_maybe = Maybe<object>.Nothing; };

        It should_not_have_a_value = () => the_maybe.HasValue.ShouldBeFalse();
    }

    [Subject("Given a maybe with nothing")]
    public class when_you_get_the_value : MaybeNothingContext
    {
        Because of = () => { exception = Catch.Exception(() => { result = the_maybe.Value; }); };

        It should_fail = () => exception.ShouldBe(typeof(InvalidOperationException));

        static Exception exception;
    }

    [Subject("Given a maybe with nothing")]
    public class when_failing_over : MaybeNothingContext
    {
        Because of = () => { result = the_maybe.Failover(the_failover); };

        It should_provide_the_failover = () => result.ShouldEqual(the_failover);

        const string the_failover = "the failover";
    }

    [Subject("Given a maybe with nothing")]
    public class when_binding : MaybeNothingContext
    {
        Because of = () => { result = the_maybe.Bind(value => Maybe.Just(the_bound_value)); };

        It should_provide_nothing = () => ((Maybe<string>) result).HasValue.ShouldBeFalse();

        const string the_bound_value = "the bound value";
    }
}
