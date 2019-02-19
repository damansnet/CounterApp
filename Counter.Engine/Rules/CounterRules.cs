using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Counter.Engine.Rules
{
    public enum CounterRules
    {
        [Description("Find Average length of word starting with {0}")]
        average_length_of_words_starting_with = 1,
        [Description("Count of {1} in words starting with {0}")]
        count_of_n_in_words_starting_with_x =2,
        [Description("Find the longest word starting with {0}")]
        longest_word_starting_with_abc = 3,
        [Description("Count the sequence of words starting with {0} and {1}")]
        count_of_sequence_of_words_starting_with_c_and_a=4
    }

    public  class RuleOutput
    {
        private  IDictionary<CounterRules, string> OutputHash = new Dictionary<CounterRules, string>() ;

       public RuleOutput()
        {
            OutputHash.Add(CounterRules.average_length_of_words_starting_with, "average_length_of_words_starting_with_{0}.txt");
            OutputHash.Add(CounterRules.count_of_n_in_words_starting_with_x, "count_of_{1}_in_words_starting_with_{0}.txt");
            OutputHash.Add(CounterRules.count_of_sequence_of_words_starting_with_c_and_a, "count_of_sequence_of_words_starting_with_{0}_and_{1}.txt");
            OutputHash.Add(CounterRules.longest_word_starting_with_abc, "longest_word_starting_with_{1}.txt");

        }

        public string GetOutputFileName(CounterRules rule)
        {
            return OutputHash[rule].ToString();
        }
        
    }

    
}
