using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace Functional.Datatypes.Specs.MaybeSpecs.ListOf
{
    [Subject("Given a mixed list of maybe an int or nothing")]
    public class when_getting_all_int_values : MixedListMaybeContext
    {
        Establish context = PopulateListWithMixedValues;

        Because of = () => { result = the_list.CatMaybes(); };

        It should_be_a_list_of_integers = () => result.ShouldContainOnly(first_integer, second_integer);

        static IEnumerable<int> result;
    }

    [Subject("Given a mixed list of maybe an int or nothing")]
    public class when_getting_all_int_values_mapped_as_another_type : MixedListMaybeContext
    {
        Establish context = PopulateListWithMixedValues;

        Because of = () => { result = the_list.MapMaybes(Convert.ToString); };

        It should_be_a_list_of_converted_integers_values = () => result.ShouldContainOnly(first_integer.ToString(), second_integer.ToString());

        static IEnumerable<string> result;
    }
}
