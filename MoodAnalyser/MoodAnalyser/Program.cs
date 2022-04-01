using System;
namespace MoodAnalyserSpace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your mood: ");
            string mood = Console.ReadLine();
            MoodAnalysers moodAnalysers = new MoodAnalysers(mood);
            string message = moodAnalysers.AnalyseMood();
            Console.WriteLine("Mood is - " + message);
        }
    }
}
