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
            Console.WriteLine("Enter any string :");
            string s = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
           
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
                    string regExInput =CheckInput(Console.ReadLine());
                    if (regExInput.Equals(string.Empty))
                        break;
                    listOfInputs.Add(regExInput);
                }
                if(listOfInputs.Count>0)
                {
                   var outputResult=  engine.Process(operation, listOfInputs);
                    string fileName = System.Environment.CurrentDirectory.ToString();
                    fileName = fileName + "\\"+ ouptutFile.GetOutputFileName(operation);
                    fileName = string.Format(fileName, listOfInputs.FirstOrDefault().Replace("|",""), (listOfInputs.Count>1)? listOfInputs.Skip(1).First().Replace("|",""):"");
                    
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
