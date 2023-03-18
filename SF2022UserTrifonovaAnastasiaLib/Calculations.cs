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
            TimeSpan time = endWorkingTime - beginWorkingTime;
            TimeSpan consultation=new TimeSpan(0,0,consultationTime);
            TimeSpan zero=new TimeSpan(0,0,0);
            
            int count=0;
            int countStartTime=startTimes.Length;
            while (time != zero)
            {
                time = time - consultation;
                count++;
            }
            string[] periods = new string[count];
            int j = 0;
            for (int i=0;i<count;i++)
            {
                if (j != countStartTime)
                {
                    TimeSpan duration = new TimeSpan(0, 0, durations[j]);
                    if (beginWorkingTime == startTimes[j])
                    {
                        beginWorkingTime = beginWorkingTime + duration;
                        j++;
                    }
                    else
                    {
                        periods[i] = string.Format("{0:hh\\:mm}-{1:hh\\:mm}", beginWorkingTime, beginWorkingTime + consultation);
                        beginWorkingTime=beginWorkingTime + consultation;
                        
                    }
                }
            }
            return periods;
        }
    }
}
