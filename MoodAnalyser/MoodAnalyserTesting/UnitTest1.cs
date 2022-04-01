using MoodAnalyserSpace;
using NUnit.Framework;


namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnalysers moodAnalyser;
        [SetUp]
        public void Setup()
        {
            string result = "";
            //Arrange
            moodAnalyser = new MoodAnalysers(result);
        }

        ///<summary>
        /// TC-1.1 Given "I am in Sad mood" message should return SAD using constructor
        ///</summary
        [Test]
        public void GivenMessage_ShouldReturnSad()
        {
            moodAnalyser = new MoodAnalysers("I am in SAD mood");
            // Act
            string message = moodAnalyser.AnalyseMood();
            // Assert
            Assert.AreEqual("SAD", message);
        }
        ///<summary>
        /// TC-1.2 Given "I am in Any mood" message should return HAPPY using constructor
        ///</summary>
        [Test]
        public void GivenMessage_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalysers("I am in ANY Mood");
            string message = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }

        /// <summary>
        /// TC-2.1 Given Null Mood Should Return Happy
        /// </summary>
        [Test]
        public void GivenMessage_WhenNull_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalysers();
            string message = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }
    }
}