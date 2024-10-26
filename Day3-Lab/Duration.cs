using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Lab
{
    /// <summary>
    /// HiringDate represent a date consists of Hours, Minutes, and Seconds.
    /// </summary>
    public class Duration
    {
        private int _seconds;
        public int Seconds
        {
            set
            {
                if (value < 0 || value > 60)
                    throw new Exception();

                _seconds = value;
            }
            get
            {
                return _seconds;
            }
        }

        private int _minutes;
        public int Minutes
        {
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentOutOfRangeException($"{value}");

                _minutes = value;
            }
            get
            {
                return _minutes;
            }
        }

        private int _hours;
        public int Hours
        {
            set
                => _hours = value;

            get
                => _hours;
        }

        public Duration(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int hours, int minutes) : this(hours, minutes, 0)
        {
        }

        public Duration(int hours) : this(hours, 0, 0)
        {
        }

        public static Duration operator +(Duration a, Duration b)
        {
            var result = new Duration();
            result.Hours = a.Hours + b.Hours;
            result.Minutes = a.Minutes + b.Minutes;
            result.Seconds = a.Seconds + b.Seconds;
            if (a.Minutes + b.Minutes >= 60)
            {
                result.Hours += (a.Minutes + b.Minutes) % 60;
                result.Minutes = (a.Minutes + b.Minutes) / 60;
            }
            if (a.Seconds + b.Seconds > 60)
            {
                result.Minutes += (a.Seconds + b.Seconds) % 60;
                result.Seconds = (a.Seconds + b.Seconds) / 60;
            }

            return result;
        }
        public static Duration operator +(int a, Duration b)
        {
            var result = new Duration();
            result.Hours = b.Hours;
            result.Minutes = b.Minutes;
            result.Seconds = b.Seconds + a;

            if (a >= 3600)
            {
                result.Hours = (a % 3600) + b.Hours;
                a /= 3600;
            }
            if (a >= 60)
            {
                result.Minutes = (a % 60) + b.Minutes;
                a /= 60;
            }

            return result;
        }

        public static Duration operator ++(Duration duration)
        {
            duration.Minutes++;
            return duration;
        }

        public static Duration operator --(Duration duration)
        {
            duration.Minutes--;
            return duration;
        }
        public override bool Equals(object? obj)
        {
            var other = obj as Duration;
            if(this.Seconds == other.Seconds
                && this.Minutes == other.Minutes
                && this.Hours == other.Hours)
                return true;

            return false;
        }

        public override string ToString()
            => $"{Hours}H:{Minutes}M:{Seconds}S";

    }
}
