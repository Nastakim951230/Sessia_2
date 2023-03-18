using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022UserTrifonovaAnastasiaLib
{
    public class Calculations
    {

        public string[] AvailablePeriods(TimeSpan[] startTimes,int[] durations,TimeSpan beginWorkingTime, TimeSpan endWorkingTime,int consultationTime)
        {
            TimeSpan time = beginWorkingTime;
            TimeSpan consultation = new TimeSpan(0, consultationTime, 0);


            int count = 0;
            int countStartTime = durations.Length;
            while (time != endWorkingTime)
            {
                time = time + consultation;
                count++;
            }

            string[] periods = new string[count];
            int j = 0;
            int k = 0;
            for (int i = 0; i <= count; i++)
            {
                if (beginWorkingTime != endWorkingTime)
                {
                    if (j != countStartTime)
                    {
                        TimeSpan duration = new TimeSpan(0, durations[j], 0);
                        if (beginWorkingTime == startTimes[j])
                        {
                            beginWorkingTime = beginWorkingTime + duration;
                            j++;
                        }
                        else if (beginWorkingTime + consultation == beginWorkingTime)
                        {
                            beginWorkingTime = beginWorkingTime + duration;
                            j++;
                        }
                        else if (beginWorkingTime + consultation > startTimes[j] && startTimes[j] >= beginWorkingTime)
                        {
                            beginWorkingTime = startTimes[j] + duration;
                            j++;
                        }


                        else
                        {
                            periods[k] = string.Format("{0:hh\\:mm}-{1:hh\\:mm} ", beginWorkingTime, beginWorkingTime + consultation);

                            beginWorkingTime = beginWorkingTime + consultation;
                            k++;

                        }
                    }
                    else
                    {

                        periods[k] = string.Format("{0:hh\\:mm}-{1:hh\\:mm} ", beginWorkingTime, beginWorkingTime + consultation);
                        beginWorkingTime = beginWorkingTime + consultation;
                        k++;
                    }
                }
            }
            return periods;
        }
    }
}
