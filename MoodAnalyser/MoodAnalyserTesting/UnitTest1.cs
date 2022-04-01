using MoodAnalyser;
using MoodAnalyserSpace;
using NUnit.Framework;


namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnalyserSpace.MoodAnalyser moodAnalyser;
        [SetUp]
        public void Setup()
        {
            string result = "";
            //Arrange
            moodAnalyser = new MoodAnalyserSpace.MoodAnalyser(result);
        }

        ///<summary>
        /// TC-1.1 Given "I am in Sad mood" message should return SAD using constructor
        ///</summary
        [Test]
        public void GivenMessage_ShouldReturnSad()
        {
            moodAnalyser = new MoodAnalyserSpace.MoodAnalyser("I am in SAD mood".ToLower());
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
            moodAnalyser = new MoodAnalyserSpace.MoodAnalyser("I am in ANY Mood".ToLower());
            string message = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }

        /// <summary>
        /// TC-2.1 Given Null Mood Should Return Happy
        /// </summary>
        [Test]
        public void GivenMessage_WhenNull_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyserSpace.MoodAnalyser();
            //Act
            string message = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("HAPPY", message);
        }

        /// <summary>
        /// TC 3.2 Given Empty Mood Should ThrowMoodAnalysisException indicating Empty Mood
        /// </summary>
        [Test]
        public void GivenMessage_WhenEmpty_CustomException()
        {
            string message = string.Empty;
            string expected = "Mood should not be Empty";
            try
            {
                //Act
                moodAnalyser = new MoodAnalyserSpace.MoodAnalyser(message);
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC 3.1 Given Null Mood Should ThrowMoodAnalysisException
        /// </summary>
        [Test]
        public void GivenMessage_WhenNull_CustomException()
        {
            string message = null;
            string expected = "Mood should not be Null";
            try
            {
                //Act
                moodAnalyser = new MoodAnalyserSpace.MoodAnalyser(message);
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

    }
}