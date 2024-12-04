using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOTC_2024.Models
{
    public class Day2Report
    {
        public bool IsSafe
        {
            get
            {
                return _IsSafe;
            }
        }
        private bool _IsSafe;

        public Day2Report(string[] values)
        {
            int previousValue = -1;


            for (int i = 0; i < values.Count(); ++i)
            {
                int currentValue = int.Parse(values[i]);

                if (previousValue != -1)
                {

                }
                else
                    previousValue = currentValue;
            }



        }

    }
}
