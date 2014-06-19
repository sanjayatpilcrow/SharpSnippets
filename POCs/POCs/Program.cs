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
using POCs.Sanjay.SharpSnippets.Geometry;
using POCs.Sanjay.SharpSnippets.Strings;
using POCs.Sanjay.SharpSnippets.Drawing;
using System.Drawing;

namespace POCs.Sanjay.SharpSnippets
{
    class Program
    {
        #region example control switches
        static bool playExampleDuration, playExampleColorExtensions, playExampleGeometrySizeScale, playExampleSafeSubString = false;
        #endregion example control switches
        static void Main(string[] args)
        {
            //set the switch for respective example to run
            #region Run example control
            playExampleGeometrySizeScale = false;
            playExampleDuration = false;
            playExampleColorExtensions = true;
            playExampleSafeSubString = false;
            #endregion //run example control

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

            #region GeometrySizeScale
            if (playExampleGeometrySizeScale)
            {
                Size OriginalSize = new Size(93, 37);
                Size ScaleTo = new Size(200, 200);
                Size ScaledSize = OriginalSize.MaintainAspectAndScale(new Size(200, 200));
                Console.WriteLine("---Start: Size Scale Example---");
                Console.WriteLine("Original Size: H-{0},W{1}", OriginalSize.Height, OriginalSize.Width);
                Console.WriteLine("Maintain aspect and scale Original To: H-{0},W{1}", ScaleTo.Height, ScaleTo.Width);
                Console.WriteLine("Scaled Size: H-{0},W{1}", ScaledSize.Height, ScaledSize.Width);
                Console.WriteLine("---End: Size Scale Example---");
            }
            #endregion //GeometrySizeScale

            #region safe subString
            if(playExampleSafeSubString)
            {
                string text = "123456";
                int start = 2, length = 6;
                Console.WriteLine("---Start: SafeSubString Example---");
                Console.WriteLine("Substring from {0}, starting @ {1} with length {2} is {3}", text, start, length, text.SafeSubstring(start, length));
                start = 7; length = 2;
                Console.WriteLine("Substring from {0}, starting @ {1} with length {2} is {3}", text, start, length, text.SafeSubstring(start, length));
                Console.WriteLine("---Start: SafeSubString Example---");
            }
            #endregion //safe subString

            #region Contrast color
            if (playExampleColorExtensions)
            {
                Console.WriteLine("---Start: Contrast color example---");
                Color color = Color.DarkRed;
                Color contrast = color.GetContrast(true);
                Console.WriteLine("Original : R-{0}, G-{1}, B-{2}", color.R, color.G,color.B);
                Console.WriteLine("Contrast : R-{0}, G-{1}, B-{2}", contrast.R, contrast.G, contrast.B);
                Console.WriteLine("---End: Contrast color example---");
            }
            #endregion //Contrast color

            Console.ReadKey();
        }
    }
}
