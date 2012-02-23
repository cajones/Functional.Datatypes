using System;
using Functional.Datatypes.Specs.MaybeSpecs;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeWithValueSpecs
{
    [Subject("Given a maybe with just a value")]
    public class when_it_has_just_a_value : MaybeContext
    {
        Because of = () => { the_maybe = Maybe.Just(the_object); };

        It should_have_a_value = () => the_maybe.HasValue.ShouldBeTrue();

        It should_provide_the_value = () => the_maybe.Value.ShouldEqual(the_object);
    }

    [Subject("Given a maybe with just a value")]
    public class when_failing_over : MaybeValueContext
    {
        Because of = () => { result = the_maybe.Failover("the failover"); };

        It should_provide_the_value = () => result.ShouldEqual(the_object);
    }
    
    [Subject("Given a maybe with just a value")]
    public class when_binding : MaybeValueContext
    {
        Because of = () => { result = the_maybe.Bind(value => Maybe.Just(the_bound_value)); };

        It should_provide_a_maybe_containing_the_bound_value = () => ((Maybe<string>)result).Value.ShouldEqual(the_bound_value);

        const string the_bound_value = "the bound value";
    }
}
