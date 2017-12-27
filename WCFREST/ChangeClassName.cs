using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFREST
{
    public class ChangeClassName
    {
        private int id;
        private string changeString;
        private string changeString1;
        private double changeDouble;
        private int changeInteger;
        private DateTime dateAndTime;

        public string ChangeString { get => changeString; set => changeString = value; }
        public string ChangeString1 { get => changeString1; set => changeString1 = value; }
        public double ChangeDouble { get => changeDouble; set => changeDouble = value; }
        public int ChangeInteger { get => changeInteger; set => changeInteger = value; }
        public int Id { get => id; set => id = value; }
        public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }

        public ChangeClassName()
        {
            
        }

        public ChangeClassName(int id, string changeString, string changeString1, double changeDouble, int changeInteger, DateTime dateAndTime)
        {
            this.id = id;
            this.changeString = changeString;
            this.changeString1 = changeString1;
            this.changeDouble = changeDouble;
            this.changeInteger = changeInteger;
            this.dateAndTime = dateAndTime;
        }
    }
}