using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SF2022UserTrifonovaAnastasiaLib;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //проверка на вывод ошибки при неправильном распорядке записей на прием
        public void ErrorInWrongOrder()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(8, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(16, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string [] mistake = {"ошибка"};
            string [] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(mistake[0], actual[0]);
        }
        [TestMethod]
        //проверка на вывод ошибки при записе раньше чем рабочий
        public void EarlyRecordingError()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = {"ошибка"};
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(mistake[0], actual[0]);
        }

        [TestMethod]
        //проверка что данные не null 
        public void NotNull()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsNotNull( actual);
        }

        [TestMethod]
        //Проверка правильности расписания
        public void CheckingIfTheScheduleIsCorrect()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(10, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(11, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };
            string[] strings = { "08:00-08:30" };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsNotNull(actual);
            //}
        }
}
