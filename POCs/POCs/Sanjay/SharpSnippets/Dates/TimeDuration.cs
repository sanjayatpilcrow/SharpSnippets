/*
 * Disclaimer
 * Unless otherwise noted, code snippets in this repository are licensed under a Creative Commons Attribution 4.0 International license (http://creativecommons.org/licenses/by/4.0/)
 * Please do not forget to credit if you choose to use code in any which way.  You can credit in any way you please as below:
        By Sanjay (http://sharpsnippets.wordpress.com/)
        By Sanjay (http://www.twitter.com/SanjayAtPilcrow)
 * Blog post about following code: http://wp.me/p2iWZr-4T
 * General Notes
 *      - This is working code, but not production code.
 *      - Code follows universal C# code convention but might not follow your company's internal convention.
 *      - Code is more of POC and thus does not have full exception handling and parameter checking.
 *      - If you choose to use the code in production, do re-code to make it production ready as per your org's engineering policy.
*/
using System;
using System.ComponentModel;

namespace POCs.Sanjay.SharpSnippets.Dates
{
    public class TimeDuration : IEquatable<TimeDuration>, INotifyPropertyChanged
    {
        #region fields
        DateTime start;
        DateTime end;
        #endregion //fields

        #region properties
        public DateTime Start
        {
            get { return start; }
            set
            {
                if (start != value)
                {
                    start = value;
                    onPropertyChanged("Start");
                }
            }
        }
        public DateTime End
        {
            get { return end; }
            set
            {
                if (end != value)
                {
                    end = value;
                    onPropertyChanged("End");
                }
            }
        }
        #endregion //properties

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion //events

        #region constructor
        public TimeDuration()
        {
            start = new DateTime();
            end = new DateTime();
        }
        public TimeDuration(DateTime Start, DateTime End)
        {
            start = Start;
            end = End;
        }
        #endregion //constructor

        #region properties
        public bool IsValidDuration
        {
            get { return start <= end; }
        }
        public TimeSpan Duration { get { return end - start; } }
        #endregion //properties

        #region public methods
        public TimeSpan IntersectingSpan(TimeDuration other)
        {
            return getIntersection(other).Duration;
        }
        public TimeDuration IntersectingDuration(TimeDuration other)
        {
            return getIntersection(other);
        }
        #endregion //public methods

        #region private methods
        private TimeDuration getIntersection(TimeDuration other)
        {
            if (this.Equals(other) || other == null) return this;
            DateTime iStart = this.Start < other.Start ? other.Start : this.Start;
            DateTime iEnd = this.End < other.End ? this.End : other.End;
            return iStart < iEnd ? new TimeDuration(iStart, iEnd) : new TimeDuration();
        }
        #endregion //private methods

        #region Equatable
        public bool Equals(TimeDuration CompareWith)
        {
            return CompareWith.Start == this.Start && CompareWith.End == this.End;
        }
        public override int GetHashCode()
        {
            return start.GetHashCode() ^ end.GetHashCode();
        }
        #endregion //Equatable

        #region notify property changed
        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }
}
