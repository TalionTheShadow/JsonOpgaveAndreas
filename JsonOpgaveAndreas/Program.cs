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
                    foreach (string option in question.Muligheder)
                    {
                        Console.WriteLine("- " + option);
                    }
                    Console.WriteLine("Svar: " + question.Svar);
                    Console.WriteLine("Forklaring: " + question.Forklaring);
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