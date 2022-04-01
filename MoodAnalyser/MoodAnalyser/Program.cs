using System;
namespace MoodAnalyserSpace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoodAnalysers moodAnalysers = new MoodAnalysers();
            Console.WriteLine("Enter mood: ");
            string mood = Console.ReadLine();
            string message = moodAnalysers.AnalyseMood(mood);
            Console.WriteLine("Mood is " + message);
        }
    }
}
