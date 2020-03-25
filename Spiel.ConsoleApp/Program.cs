using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
     
            Question frage1 = new Question("Zahlungsunfähigkeit nennt man auch?");
            frage1.AddAnswer(new Answer("Spiel beenden"));
            frage1.AddAnswer(new Answer("Insolvenz", true));
            frage1.AddAnswer(new Answer("Karenz"));
            frage1.AddAnswer(new Answer("Insolation"));
            frage1.AddAnswer(new Answer("Instanz"));
            game.AddQuestion(frage1);

            Question frage2 = new Question("Wie heißt die japanische Währung?");
            frage2.AddAnswer(new Answer("Spiel beenden"));
            frage2.AddAnswer(new Answer("Rand"));
            frage2.AddAnswer(new Answer("Yen",true));
            frage2.AddAnswer(new Answer("Dollar"));
            frage2.AddAnswer(new Answer("Rupie"));
            game.AddQuestion(frage2);

            Question frage3 = new Question("Das staatlich festgelegte Preismaximum ist zum Schutze der...?");
            frage3.AddAnswer(new Answer("Spiel beenden"));
            frage3.AddAnswer(new Answer("Arbeitslosen"));
            frage3.AddAnswer(new Answer("Produzenten"));
            frage3.AddAnswer(new Answer("Verbraucher", true));
            frage3.AddAnswer(new Answer("Oligopolisten"));
            game.AddQuestion(frage3);

            while (game.Status == GameStatus.Active)
            {
                var frage = game.NextQuestion;
                var antworten = frage.Answers;

                int counter = 0;
                //Frage
                Console.WriteLine("\n {0}",frage.Text);
                //Antworten
                foreach (var item in antworten)
                {
                    Console.WriteLine("{0}) {1}", counter, item.Text);
                    counter++;

                }
                //Eingabe
                Console.Write("\n Eingabe: ");
                int eingabe = Convert.ToInt32(Console.ReadLine());

                if (eingabe == 0)
                {
                    game.ValidateCurrentQuestion();
                }
                else
                {
                    antworten[eingabe].IsChecked = true;
                }

                game.ValidateCurrentQuestion();
            }
            //Gewonnen, Verloren
            if (game.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("TO EASY FOR YOU!! CONGRATS, YOU WON!");
            }
            else
            {
                Console.WriteLine("YOU HAVE TO STUDY HARDER! YOU LOST THE GAME!");
            }
        }
    }
}
