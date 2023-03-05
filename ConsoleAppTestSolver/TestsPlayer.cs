using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestSolver
{
    internal class TestsPlayer
    {
        private List<TestExample> _testExamples;

        public TestsPlayer()
        {
            _testExamples = new List<TestExample>();
        }

        public void LoadFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            int examplesCount = int.Parse(reader.ReadLine());
            
            for (int i = 0; i < examplesCount; i++)
            {
                string question = reader.ReadLine();
                int countAnswers = int.Parse(reader.ReadLine());

                List<string> answers = new List<string>();

                for (int j = 0; j < countAnswers; j++)
                {
                    answers.Add(reader.ReadLine());
                }

                int indexRightAnswer = int.Parse(reader.ReadLine());


                _testExamples.Add(new TestExample()
                {
                    Question = question,
                    Answers = answers,
                    IndexRightAnswers = indexRightAnswer
                }) ;
            }

            reader.Close();
        }

    }
}
