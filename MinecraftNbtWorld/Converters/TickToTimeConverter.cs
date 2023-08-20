using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorld.Converters
{
    public class TickToTimeConverter
    {
        public static double TicksToSeconds(long ticks)
        {
            return ticks / 20.0;
        }

        public static double TicksToMinutes(long ticks)
        {
            return ticks / (20.0 * 60.0);
        }

        public static double TicksToSeconds(long? ticks)
        {
            if (ticks == null)
            {
                return 0;
            }
            return (double)(ticks / 20.0);
        }

        public static double TicksToMinutes(long? ticks)
        {
            if (ticks == null)
            {
                return 0;
            }
            return (double)(ticks / (20.0 * 60.0));
        }

        public static DateTime GetTimeFromSecons(long seconds)
        {
            long lastPlayedTimestampMillis = 1630835323000; // Replace with your actual lastplayed value

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(lastPlayedTimestampMillis);

            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
        }

        public static DateTime GetTimeFromSecons(long? seconds)
        {
            if (seconds == null)
            {
                return DateTime.MinValue ;
            }
            long lastPlayedTimestampMillis = 1630835323000; // Replace with your actual lastplayed value

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(lastPlayedTimestampMillis);

            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
        }
    }
}
