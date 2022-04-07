using MoodAnalyserSpace;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalysers
{
    public class MoodAnalyserFactory
    {
        public string mood;
        public static object CreateMoodAnalyser(string className, string constructorName)
        {

            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            //computaion
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyser = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyser);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchClass, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchConstructor, "Constructor not found");
            }
        }

        public static object CreateMoodAnalyserWithParameterisedConstructor(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.FullName.Equals(className) || type.Name.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object obj = constructorInfo.Invoke(new[] { "Happy" });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchConstructor, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchClass, "Class not found");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserSpace.MoodAnalyser");//ClassName
                object moodAnalyse = CreateMoodAnalyserWithParameterisedConstructor(
                    "MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser");//namespace with class name
                MethodInfo methodInfo = type.GetMethod(methodName);//Methodname
                object moodInvoke = methodInfo.Invoke(moodAnalyse, null); // Namespace.classname.methodname
                return (string)moodInvoke;
            }
            catch (Exception)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchConstructor, "Constructor not found");
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                //FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                FieldInfo field = type.GetField(fieldName);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchField, "Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.Mood;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NoSuchField, "Field is Not Found");
            }
        }
    }
}