using Machine.Specifications;

namespace Functional.Datatypes.Specs.EitherSpecs
{
    [Subject("Given either an int or string, that is a string")]
    public class when_analysing_if_it_is_a_string : EitherContext
    {
        Establish context = () =>
                                {
                                    the_string = "i am the string";
                                    the_either = Either<int, string>.Right(the_string);
                                };

        Because of = () => { result = the_either.Analyse(i => false, s => true); };

        It should_be_a_string = () => result.ShouldBeTrue();

        static bool result;
    }
}
