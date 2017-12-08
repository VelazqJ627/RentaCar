using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Rent
    {
        //private Variables
        private int rentId = 0;
        private string id = "n/a";
        private string carMake = "n/a";
        private string carModel = "n/a";
        private int daysUse = 0;
        private string dateStart = "n/a";
        private string dateEnd = "n/a";
        private int mileageStart = 0;
        private int mileageEnd = 0;
        private double total = 0;

        //get and set
        public int RentId { get { return this.rentId; } set { this.rentId = value; } }
        public string Id { get { return this.id; } set { this.id = value; } }
        public string CarMake { get { return this.carMake; } set { this.carMake = value; } }
        public string CarModel { get { return this.carModel; } set { this.carModel = value; } }
        public int DaysUse { get { return this.daysUse; } set { this.daysUse = value; } }
        public string DateStart { get { return this.dateStart; } set { this.dateStart = value; } }
        public string DateEnd { get { return this.dateEnd; } set { this.dateEnd = value; } }
        public int MileageStart { get { return this.mileageStart; } set { this.mileageStart = value; } }
        public int MileageEnd { get { return this.mileageEnd; } set { this.mileageEnd = value; } }
        public double Total { get { return this.total; } set { this.total = value; } }

        //tostring
        public override string ToString()
        {
            string aMessage = "n/a";
            aMessage = aMessage + "RentId: " + RentId + "<br />";
            aMessage = aMessage + "Id: " + Id + "<br />";
            aMessage = aMessage + "CarMake: " + CarMake + "<br />";
            aMessage = aMessage + "CarModel: " + CarModel + "<br />";
            aMessage = aMessage + "DaysUse: " + DaysUse + "<br />";
            aMessage = aMessage + "DateStart: " + DateStart + "<br />";
            aMessage = aMessage + "DateEnd: " + DateEnd + "<br />";
            aMessage = aMessage + "MileageStart: " + MileageStart + "<br />";
            aMessage = aMessage + "MileageEnd: " + MileageEnd + "<br />";
            aMessage = aMessage + "Total: " + Total + "<br />";

            return aMessage;
        }

        //constructor

        public Rent()
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse, string aDateStart, string aDateEnd, int aMileageStart, int aMileageEnd, double aTotal)
        {
            this.RentId = aRentId;
            this.Id = aId;
            this.CarMake = aCarMake;
            this.CarModel = aCarModel;
            this.DaysUse = aDaysUse;
            this.DateStart = aDateStart;
            this.DateEnd = aDateEnd;
            this.MileageStart = aMileageStart;
            this.MileageEnd = aMileageEnd;
            this.Total = aTotal;
        }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse, string aDateStart, string aDateEnd, int aMileageStart, int aMileageEnd)
            : this(aRentId, aId, aCarMake, aCarModel, aDaysUse, aDateStart, aDateEnd, aMileageStart, aMileageEnd, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse, string aDateStart, string aDateEnd, int aMileageStart)
            : this(aRentId, aId, aCarMake, aCarModel, aDaysUse, aDateStart, aDateEnd, aMileageStart, 0, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse, string aDateStart, string aDateEnd)
            : this(aRentId, aId, aCarMake, aCarModel, aDaysUse, aDateStart, aDateEnd, 0, 0, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse, string aDateStart)
            : this(aRentId, aId, aCarMake, aCarModel, aDaysUse, aDateStart, "n/a", 0, 0, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel, int aDaysUse)
            : this(aRentId, aId, aCarMake, aCarModel, aDaysUse, "n/a", "n/a", 0, 0, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake, string aCarModel)
            : this(aRentId, aId, aCarMake, aCarModel, 0, "n/a", "n/a", 0, 0, 0)
        { }

        public Rent(int aRentId, string aId, string aCarMake)
            : this(aRentId, aId, aCarMake, "n/a", 0, "n/a", "n/a", 0, 0, 0)
        { }

        public Rent(int aRentId, string aId)
            : this(aRentId, aId, "n/a", "n/a", 0, "n/a", "n/a", 0, 0, 0)
        { }
    }
}