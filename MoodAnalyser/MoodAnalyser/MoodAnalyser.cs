using MoodAnalysers;
using System;


namespace MoodAnalyserSpace
{
    public class MoodAnalyser
    {
        private string _message;

        public MoodAnalyser()
        {

        }
        public MoodAnalyser(string message = "Null")
        {
            _message = message;
        }

        public string AnalyseMood()
        {
            try
            {
                if (_message.Equals(string.Empty))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EmptyMood, "Mood should not be Empty");
                else if (_message.ToLower().Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                //throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NullMood, "Mood should not be Null");
                return "HAPPY";
            }
        }
    }
}
