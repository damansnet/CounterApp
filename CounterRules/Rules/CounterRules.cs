using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterRules.Rules
{
    public enum CounterRules
    {
        [Description("Find Average length of word starting with {0}")]
        average_length_of_words_starting_with = 1,
        [Description("Count of {0} in words starting with {1}")]
        count_of_n_in_words_starting_with_x =2,
        [Description("Find the longest word starting with {0}")]
        longest_word_starting_with_abc = 3,
        [Description("Count the sequence of words starting with {0} and {1}")]
        count_of_sequence_of_words_starting_with_c_and_a=4

    }
    
}
