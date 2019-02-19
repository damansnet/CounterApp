using Counter.Engine;
using Counter.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string regexStartWith = @"(?<!\w)[{0}]\w+";
            //count rule 1
            /*
            For all the words startw with 'a' or 'A', count average length of words, save the result. to file "average_length_of_words_starting_with_a.txt
             */
            string s = "Lorem ipsum text Second cold amp lorem ipsum. How are You. It's ok. Done. bell beet BEat Something else now. Cut Apple ";
            //var matches = Regex.Matches(s, string.Format(regexStartWith, "a|A"));// "(?<!\w)[a|A]\w+");

            //var totalLength = matches.Cast<Match>().Select(m => m.Length).Sum();
            //var average = totalLength / matches.Cast<Match>().Count();
            //Console.WriteLine(average);
          

            //count rule 2
            /*
             for all the words starts with "b" or "B", count the total number of "e" or "E" in the words, save the result to the file "count_of_e_in_words_starting_with_b.txt
             */
           // string s = "Lorem ipsum text Second lorem ipsum. How are You. It's ok. Done. Something else now. Apple";
            //var matchesRule2 = Regex.Matches(s, string.Format(regexStartWith, "b|B"));
            //var findLetterRegEx = @"[e|E]";
            //var totalLength2 = matchesRule2.Cast<Match>().Select(m =>Regex.Matches(m.Value,findLetterRegEx).Count).Sum();
            //var count_of_e_in_words_starting_b = totalLength2;
            //Console.WriteLine(count_of_e_in_words_starting_b);
            


            //count rule 3
            /*
             For all the words starts with a or b or c get the longest length of words. save the result to the file.
             longest_words_starting with_abc.txt
             */
            //var matchesRule3= Regex.Matches(s, string.Format(regexStartWith, "a|A|b|B|c|C"));
            //var longestLength = matchesRule3.Cast<Match>().Select(m =>m.Length).Max();
            //Console.WriteLine(longestLength);

            //count rule 4
            //var rule4 = @"(?<!\w)[{0}](\w+)\s((?<!\w)[{1}](\w+))";
            //var matchesRule4 = Regex.Matches(s, string.Format(rule4, "c|C","a|A"));
            //var matchesRule4_1 = string.Format(regexStartWith, "a|A");
            //var numberofOccurence = matchesRule4.Cast<Match>().Select(m => m.Groups[2].Value).Count();
            //Console.WriteLine(numberofOccurence);

            Start(s);

            Console.Read();
        }

        public static void Start(string s)
        {

            CounterEngine engine = new CounterEngine(s);
            Array AllRules = Enum.GetValues(enumType: typeof(CounterRules));
            RuleOutput ouptutFile = new RuleOutput();
           // string[] Rules = AllRules.Split('|');
            
            Console.WriteLine("You can skip rule by entering -1 for input.");
            foreach (var rule in AllRules)
            {

                List<string> listOfInputs = new List<string>();
                System.Diagnostics.Debug.Print(rule.ToString());

                var operation = (CounterRules) Enum.Parse(typeof(CounterRules),Convert.ToString(rule) );
                var description = engine.GetRuleDescription(operation);
                Console.WriteLine(description);
                var pattern = @"{(.*?)}";
                var matches = Regex.Matches(description, pattern);
                foreach(var input in matches)
                {
                    Console.Write(input);
                    string regExInput =CheckInput(Console.ReadLine());
                    if (regExInput.Equals(string.Empty))
                        continue;
                    listOfInputs.Add(regExInput);
                }
                if(listOfInputs.Count>0)
                {
                   var outputResult=  engine.Process(operation, listOfInputs);
                    string fileName = System.Environment.CurrentDirectory.ToString();
                    fileName = fileName + "\\"+ ouptutFile.GetOutputFileName(operation);

                    OutputWriter.WriteToFile(outputResult, fileName);
                }

            }
        }

        private static string CheckInput(string v )
        {
            if(v=="-1")
            {
                return string.Empty;
            }
            return v;
        }
    }
}
