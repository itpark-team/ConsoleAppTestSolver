using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestSolver
{
    class TestsPlayer
    {
        private List<TestExample> _testExamples;

        public TestsPlayer()
        {
            _testExamples = new List<TestExample>();
        }

        public void LoadFromFile(string fileName)
        {
            _testExamples.Clear();
            
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

                int numberRightAnswer = int.Parse(reader.ReadLine());


                _testExamples.Add(new TestExample()
                {
                    Question = question,
                    Answers = answers,
                    NumberRightAnswers = numberRightAnswer
                });
            }

            reader.Close();
        }

        public void RunTests()
        {
            int countExamples = _testExamples.Count;

            int countRightAnswers = 0;
            int countWrongAnswers = 0;

            int numberCurrentExample = 0;

            foreach (TestExample example in _testExamples)
            {
                Console.Clear();

                numberCurrentExample++;
                Console.WriteLine($"Номер вопроса {numberCurrentExample}/{countExamples}");

                Console.WriteLine(example.Question);

                int numberCurrentAnswer = 0;
                foreach (string answer in example.Answers)
                {
                    numberCurrentAnswer++;
                    Console.WriteLine($"{numberCurrentAnswer}. {answer}");
                }
                
                int numberUserAnswer = Util.InputInt("Выберите номер ответ: ",1,example.Answers.Count);
                if (numberUserAnswer == example.NumberRightAnswers)
                {
                    countRightAnswers++;
                }
                else
                {
                    countWrongAnswers++;
                }
            }

            Console.Clear();

            Console.WriteLine($"Всего вопросов: {countExamples}");
            Console.WriteLine($"Праивльных ответов: {countRightAnswers}");
            Console.WriteLine($"Неправильных ответов: {countWrongAnswers}");
            Console.WriteLine($"Процент правильных ответов: {string.Format("{0:0.00}",countRightAnswers * 100.0 / countExamples)}%");
            
            Console.WriteLine("Нажмите что угодно чтобы продолжить");
            Console.ReadKey();
        }
    }
}
