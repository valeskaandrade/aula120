using System;

namespace Teste.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public Double ValuePerHour { get; set; }
        public int Hours { get; set; }
        public HourContract(DateTime date, double valueperhour, int hours) 
        { 
            Date = date;
            ValuePerHour = valueperhour;
            Hours = hours;
        }
        public HourContract() 
        { 
        }

        public double TotalValue() 
        {
            return Hours * ValuePerHour;      
        }

        
    }
}
