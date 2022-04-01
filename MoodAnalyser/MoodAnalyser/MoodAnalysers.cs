using System;
namespace MoodAnalyserSpace
{
    public class MoodAnalysers
    {
        private string message;
        public MoodAnalysers()
        {

        }
        public MoodAnalysers(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("sad"))
                    return "SAD";
                else return "HAPPY";
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
