using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    class TaxCalculator
    {
        /// <summary>
        /// Calculates the Tax amount for a Residential Employee
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public static double CalculateResidentialTax(double gross) 
        {
            double tax = 0;
            double A = 0, 
                   B = 0;

            if (gross > -1 && gross <= 72)
            {
                A = 0.19;
                B = 0.19;
            }
            else if (gross > 72 && gross <= 361)
            {
                A = 0.2342;
                B = 3.213;
            }
            else if (gross > 361 && gross <= 932)
            {
                A = 0.3477;
                B = 44.2476;
            }
            else if (gross > 932 && gross <= 1380) {
                A = 0.345;
                B = 41.7311;
            }
            else if (gross > 1380 && gross <= 3111) {
                A = 0.39;
                B = 103.8657; 
            }
            else if (gross > 3111 && gross <= 999999) {
                A = 0.47;
                B = 352.7888; 
            }

            tax = A * gross - B; 
            
            return tax; 
        }

        /// <summary>
        /// Calculates the Tax for a Working Holiday Employee 
        /// </summary>
        /// <param name="gross"></param>
        /// <param name="yearToDate"></param>
        /// <returns></returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate) {
            double rate = 0;
            double totalGross = gross + yearToDate;
            double tax;

            if (totalGross > -1 && totalGross <= 37000) {
                rate = 0.15; 
            }
            else if (totalGross > 37000 && totalGross <= 90000)
            {
                rate = 0.32; 
            }
            else if (totalGross > 90000 && totalGross <= 180000)
            {
                rate = 0.37; 
            }
            else if (totalGross > 180000 && totalGross <= 9999999) {
                rate = 0.45; 
            }

            tax = gross * rate;
            return tax; 
        }

    }
}
