using Counter.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Counter.Engine
{
    public class CounterEngine
    {
        private const string _baseRegEx = @"(?<!\w)[{0}]\w+";
        private const string _occurenceRegEx=@"[{0}]";
        private readonly string _inputText;

        public CounterEngine(string inputText)
        {
            _inputText = inputText;
        }

        public string GetCounterRules()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (CounterRules rule in Enum.GetValues(enumType: typeof(CounterRules)))
            {
                stringBuilder.Append(rule.GetDescription() + "|");
            }
            return stringBuilder.ToString();
        }

        public string GetRuleDescription(CounterRules counterRule)
        {
            return counterRule.GetDescription();
        }

        public int Process(CounterRules operation, List<string> listOfInputs)
        {
            switch (operation)
            {
                case CounterRules.average_length_of_words_starting_with:
                    return FindAverageLengthWordsStartingWith(listOfInputs);
                case CounterRules.count_of_n_in_words_starting_with_x:
                    return CounthWordsStartingWith(listOfInputs);
                case CounterRules.count_of_sequence_of_words_starting_with_c_and_a:
                    return CountSequenceOfWords(listOfInputs);
                case CounterRules.longest_word_starting_with_abc:
                    return FindLongestWordStartingWith(listOfInputs);
            }

            return -1;
        }

        private int FindLongestWordStartingWith(List<string> listOfInputs)
        {
            var matches = Regex.Matches(_inputText, string.Format(_baseRegEx, listOfInputs.FirstOrDefault()));
            var longestLength =(matches.Count>0)? matches.Cast<Match>().Select(m => m.Length).Max() : 0;
            Console.WriteLine(longestLength);
            return longestLength;
        }

        private int CountSequenceOfWords(List<string> listOfInputs)
        {
            var wordStartsWithPattern = string.Format(_baseRegEx, listOfInputs.FirstOrDefault());
            var sequenceStartsWithPattern = string.Format(_baseRegEx, listOfInputs.Skip(1).First());
            var combinedPattern =wordStartsWithPattern+@"\s"+sequenceStartsWithPattern ;
            var match = Regex.Matches(_inputText, combinedPattern);
            var numberofOccurence =(match.Count>0) ? match.Cast<Match>().Select(m => m.Groups[2].Value).Count() : 0;
            Console.WriteLine(numberofOccurence);
            return numberofOccurence;
        }

        private int CounthWordsStartingWith(List<string> listOfInputs)
        {
            var patternFindWordStarts = string.Format(_baseRegEx, listOfInputs.FirstOrDefault());
            var findLetterRegEx = string.Format(_occurenceRegEx, listOfInputs.Skip(1).First());
            var matches = Regex.Matches(_inputText,patternFindWordStarts);
            var totalLength =(matches.Count>0)?  matches.Cast<Match>().Select(m => Regex.Matches(m.Value, findLetterRegEx).Count).Sum() : 0;
            Console.WriteLine(totalLength);
            return totalLength;
        }

        private int FindAverageLengthWordsStartingWith(List<string> listOfInputs)
        {
            var pattern = string.Format(_baseRegEx, listOfInputs.FirstOrDefault());
            var matches = Regex.Matches(_inputText, pattern);

            var totalLength = matches.Cast<Match>().Select(m => m.Length).Sum();
            var average =(matches.Count>0)?totalLength / matches.Cast<Match>().Count():0;
            Console.WriteLine(average);
            return average;
        }


    }
}
