namespace MoodAnalyserSpace
{
    public class MoodAnalysers
    {
        public MoodAnalysers()
        {

        }

        public string AnalyseMood(string message)
        {
            if (message.ToLower().Contains("sad"))
                return "SAD";
            else return "HAPPY";
        }
    }
}
