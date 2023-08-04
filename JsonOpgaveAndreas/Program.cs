using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonOpgaveAndreas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("C:\\Users\\ACB\\source\\repos\\JsonOpgaveAndreas\\JsonOpgaveAndreas\\json1.json");
            QuizData quizData = JsonConvert.DeserializeObject<QuizData>(json);

            foreach (QuizQuestion question in quizData.Spørgsmål)
            {
                Console.WriteLine("Spørgsmål: " + question.Spørgsmål1);
                Console.WriteLine("Muligheder:");

                // Display options with numbers (1, 2, 3, etc.) for the user to choose from.
                for (int i = 0; i < question.Muligheder.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Muligheder[i]}");
                }

                // Prompt the user for input
                int userChoice;
                do
                {
                    Console.Write("Indtast dit svar ved at vælge et tal (1, 2, 3, ...): ");
                } while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > question.Muligheder.Length);

                // Check the user's answer
                if (question.Muligheder[userChoice - 1] == question.Svar)
                {
                    Console.WriteLine("Korrekt svar!");
                    Console.WriteLine("Forklaring: " + question.Forklaring);
                }
                else
                {
                    Console.WriteLine("Forkert svar!");
                    Console.WriteLine("Korrekt svar er: " + question.Svar);
                }

                Console.WriteLine();
            }
        }
    }

    public class QuizQuestion
    {
        public string Spørgsmål1 { get; set; }
        public string[] Muligheder { get; set; }
        public string Svar { get; set; }
        public string Forklaring { get; set; }

    }

    public class QuizData
    {
        public List<QuizQuestion> Spørgsmål { get; set; }
    }
}
