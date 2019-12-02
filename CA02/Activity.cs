using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA02
{
    public class Activity:IComparable<Activity>
    {
        public enum ActType { Land, Water, Air}

        public decimal Price { get; set; }
        public DateTime SetDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public ActType TypeAct { get; set; }

        public override string ToString()
        {
            return $"{Category} - {SetDate.ToShortDateString()}";
        }

        public int CompareTo(Activity other)
        {
            return SetDate.CompareTo(other.SetDate);
        }
    }
}
