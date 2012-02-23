using System.Collections.Generic;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.EitherSpecs.ListOf
{
    [Subject("Given a mixed list of either int or strings")]
    public class when_getting_lefts : MixedListEitherContext
    {
        Establish context = PopulateListWithMixedValues;

        Because of = () => { result = the_list.Lefts(); };

        It should_be_a_list_of_integers = () => result.ShouldContainOnly(first_integer, second_integer);

        static IEnumerable<int> result;
    }

    [Subject("Given a mixed list of either int or strings")]
    public class when_getting_rights : MixedListEitherContext
    {
        Establish context = PopulateListWithMixedValues;

        Because of = () => { result = the_list.Rights(); };

        It should_be_a_list_of_strings = () => result.ShouldContainOnly(first_string, second_string);

        static IEnumerable<string> result;
    }
}
