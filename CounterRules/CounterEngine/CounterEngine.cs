using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CounterRules.Rules;
namespace CounterRules.CounterEngine
{
    public class CounterEngine
    {


        public  string GetCounterRules()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (CounterRules.Rules.CounterRules rule in Enum.GetValues(enumType: typeof(CounterRules.Rules.CounterRules)))
            {
                stringBuilder.Append(rule.GetDescription()+ "|");
            }
            return stringBuilder.ToString();
        }

        public string GetRuleDescription(CounterRules.Rules.CounterRules  counterRule)
        {
            return counterRule.GetDescription();
        }

        internal void Process(Rules.CounterRules operation, List<string> listOfInputs)
        {
            throw new NotImplementedException();
        }
    }
}
