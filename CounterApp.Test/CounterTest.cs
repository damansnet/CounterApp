using System;
using System.Collections.Generic;
using Counter.Engine;
using Counter.Engine.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CounterApp.Test
{
    [TestClass]
    public class CounterTest
    {
        private readonly  string inputString = "Brown fox jumps over the moon to cross the river and get over to the other side.";
        [TestMethod]
        public void TestMethod1()
        {
        }
        
        [TestMethod]
        public void TestAverageLengthOfWordStartingWith_N()
        {
           
            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("t|T"); // char | donates the or condition it will look for work starts with t or T
            //testing the rule 1.
            var result = engine.Process(CounterRules.average_length_of_words_starting_with, searchInput);

            Assert.AreEqual(result, 2); // 


        }

        [TestMethod]
        public void TestAverageLengthOfWordStartingWith_N_returnsZero()
        {

            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("x|X|T|M"); // char | donates the or condition it will look for work starts with t or T
            //testing the rule 1.
            var result = engine.Process(CounterRules.average_length_of_words_starting_with, searchInput);

            Assert.AreEqual(result, 0); // 


        }



        [TestMethod]
        public void TestCountOfNInWordsStartsWithT()
        {

            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("o|O");
            searchInput.Add("e|r");
            var result = engine.Process(CounterRules.count_of_n_in_words_starting_with_x, searchInput);

            Assert.AreEqual(result, 6); // 


        }

        [TestMethod]
        public void TestCountOfNInWordsStartsWithT_returnsZero()
        {

            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("j");
            searchInput.Add("a");
            var result = engine.Process(CounterRules.count_of_n_in_words_starting_with_x, searchInput);

            Assert.AreEqual(result, 0); // 


        }

        [TestMethod]
        public void TestCountOfSequenceOfWordStartingWithNAndA()
        {

            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("B");
            searchInput.Add("f");
            var result = engine.Process(CounterRules.count_of_sequence_of_words_starting_with_c_and_a, searchInput);

            Assert.AreEqual(result, 1); // 


        }

        [TestMethod]
        public void TestLongestWordStartingWintABC()
        {

            CounterEngine engine = new CounterEngine(inputString);
            List<string> searchInput = new List<string>();
            searchInput.Add("b|B|o|O|r|R");
          
            var result = engine.Process(CounterRules.longest_word_starting_with_abc, searchInput);

            Assert.AreEqual(result, 5); // 


        }
    }
}
