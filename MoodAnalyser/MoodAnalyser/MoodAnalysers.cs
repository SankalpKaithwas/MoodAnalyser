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
            if (message.ToLower().Contains("sad"))
                return "SAD";
            else return "HAPPY";
        }
    }
}
