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
        //проверка на вывод ошибки при записе позже чем рабочий
        public void ErrorsWhenWritingLaterThanWorking()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 0);

            TimeSpan timeSpan = new TimeSpan(8, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(19, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
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
            string[] strings = { "08:00-08:30", "08:30-09:00", "09:00-09:30", "09:30-10:00", "11:30-12:00", "12:00-12:30", "12:30-13:00", "13:00-13:30", "13:30-14:00", "14:00-14:30", "14:30-15:00", "15:40-16:10", "16:10-16:40", "17:30-18:00",null,null,null,null,null,null};
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            int count = 0;
            int countRaspisanie=actual.Length;
            for(int i = 0; i < actual.Length; i++)
            {
                if(actual[i] ==strings[i])
                {
                    count++;
                }
            }
            Assert.AreEqual(count, countRaspisanie);
        }


        [TestMethod]
        //проверка на вывод ошибки при одинаковом начале и конце насписания
        public void ErrorStartAndEndOfWorkShift()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 0, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(mistake[0], actual[0]);
        }


        [TestMethod]
        //проверка тип данных
        public void DataType()
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
            Assert.IsInstanceOfType(actual, typeof(string[]));
        }
        [TestMethod]
        //проверка на вывод ошибки при одинаковых времени записей
        public void SameTimeRecordingError()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(mistake[0], actual[0]);
        }

        [TestMethod]
        //проверка на вывод ошибки при близких временых записей
        public void ErrorsAtCloseTimeRecords()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 00, 0);

            TimeSpan timeSpan = new TimeSpan(7, 0, 0);
            TimeSpan timeSpan1 = new TimeSpan(9, 0, 0);
            TimeSpan timeSpan2 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan3 = new TimeSpan(15, 30, 0);
            TimeSpan timeSpan4 = new TimeSpan(16, 50, 0);
            int[] durations = { 60, 30, 10, 10, 40 };
            int consultationTime = 30;
            TimeSpan[] startTimes = { timeSpan, timeSpan1, timeSpan2, timeSpan3, timeSpan4 };

            string[] mistake = { "ошибка" };
            string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(mistake[0], actual[0]);
        }
    }
}
