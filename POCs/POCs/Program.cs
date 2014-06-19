/*
 * Disclaimer
 * Unless otherwise noted, code snippets in this repository are licensed under a Creative Commons Attribution 4.0 International license (http://creativecommons.org/licenses/by/4.0/)
 * Please credit if you choose to use code in any which way. You can credit in any way you please as below:
        By Sanjay (http://sharpsnippets.wordpress.com/)
        By Sanjay (http://www.twitter.com/SanjayAtPilcrow)
 * General Notes
 *      - This is working code, but not production code.
 *      - Code follows universal C# code convention but might not follow your company's internal convention.
 *      - Code is more of POC and thus does not have full exception handling and parameter checking.
 *      - If you choose to use the code in production, do re-code to make it production ready as per your org's engineering policy.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCs.Sanjay.SharpSnippets.Dates;

namespace POCs.Sanjay.SharpSnippets
{
    class Program
    {
        #region example control switches
        static bool playExampleDuration, playExampleDateExtensions = false;
        #endregion example control switches
        static void Main(string[] args)
        {
            //set the switch for respective exampl to run
            playExampleDuration = false;
            
            #region TimeDuration test
            if (playExampleDuration)
            {
                DateTime now = DateTime.Now;
                TimeDuration duration1 = new TimeDuration(now, now.Subtract(new TimeSpan(1, 30, 30)));
                TimeDuration duration2 = new TimeDuration(now, now.Add(new TimeSpan(1, 30, 30)));
                TimeDuration duration3 = new TimeDuration(now.Subtract(new TimeSpan(0, 30, 0)), now.Add(new TimeSpan(0, 30, 0)));
                Console.WriteLine("---Start: Duration Example---");
                //If Start is smaller than End, duration is valid
                Console.WriteLine("Duration 1 is {0}", duration1.IsValidDuration ? "Valid" : "Invalid");
                Console.WriteLine("Duration 2 is {0}", duration2.IsValidDuration ? "Valid" : "Invalid");
                //Returns a new duration with overlapping Start and End 
                Console.WriteLine("Duration 2 and Duration 3 overlap for duration - From {0} to {1}", duration2.IntersectingDuration(duration3).Start, duration2.IntersectingDuration(duration3).End);
                //Returns a new TimeSpan object with overlapping time span
                Console.WriteLine("Duration 2 and Duration 3 overlap for splan - {0}", duration2.IntersectingSpan(duration3));
                Console.WriteLine("---End: Duration Example---");
            }
            #endregion TimeDuration test

            Console.ReadKey();
        }
    }
}
