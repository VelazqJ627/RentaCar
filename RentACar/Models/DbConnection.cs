using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.Odbc;

namespace RentACar.Models
{
    public class DbConnection
    {
        private List<Rent> aListOfRent = new List<Rent>();


        //Start of GetRent Method

        public List<Rent> GetRent()
        {
            //oledb is a tool/technology which is the license to the DB
            OleDbConnection aConnection = new OleDbConnection();
            //basic sql
            string aSQL = "SELECT RentId, Id, CarMake, CarModel, DaysUse, DateStart, DateEnd, MileageStart, MileageEnd, Total FROM RentCar;";
            //@"provider etc = depends on your driver ;Data SOurce=connection to the database string 
            aConnection.ConnectionString = @"Provider=sqloledb;
            Data Source=MSI;Initial Catalog=RentACar;Integrated Security=SSPI;";
            aConnection.Open();
            //aCommand tells the database what to do
            OleDbCommand aCommand = aConnection.CreateCommand();
            //which is to do the sql statement
            aCommand.CommandText = aSQL;

            //run sql and run it into aReader variable which turns it into a spreadsheet
            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {

                int aRentId = (int)aReader["RentId"];
                string aId = (string)aReader["Id"];
                string aCarMake = (string)aReader["CarMake"];
                string aCarModel = (string)aReader["CarModel"];
                int aDaysUse = (int)aReader["DaysUse"];
                string aDateStart = (string)aReader["DateStart"];
                string aDateEnd = (string)aReader["DateEnd"];
                int aMileageStart = (int)aReader["MileageStart"];
                int aMileageEnd = (int)aReader["MileageEnd"];
                double aTotal = (double)aReader["Total"];
                

                Rent aRent = new Rent();

                aRent.RentId = aRentId;
                aRent.Id = aId;
                aRent.CarMake = aCarMake;
                aRent.CarModel = aCarModel;
                aRent.DaysUse = aDaysUse;
                aRent.DateStart = aDateStart;
                aRent.DateEnd = aDateEnd;
                aRent.MileageStart = aMileageStart;
                aRent.MileageEnd = aMileageEnd;
                aRent.Total = aTotal;
                

                aListOfRent.Add(aRent);
            }
            aConnection.Close();

            return aListOfRent;
        }

        public bool InsertRent(string Id, string CarMake, string CarModel, int DaysUse, string DateStart, string DateEnd, int MileageStart, int MileageEnd, double Total)

        {

            bool aFlag = false;
            string aSQL = "INSERT INTO RentCar (Id, CarMake, CarModel, DaysUse, DateStart, DateEnd, MileageStart, MileageEnd, Total )";
            aSQL = aSQL + "VALUES('" + Id + "','" + CarMake + "','" + CarModel + "', '" + DaysUse + "','" + DateStart + "','" + DateEnd + "', '" + MileageStart + "','" + MileageEnd + "','" + Total + "') ";

            //oledb is a tool/technology which is the license to the DB
            OleDbConnection aConnection = new OleDbConnection();
            aConnection.ConnectionString = @"Provider=sqloledb;
            Data Source=MSI;Initial Catalog=RentACar;Integrated Security=SSPI";
            aConnection.Open();
            //aCommand tells the database what to do
            OleDbCommand aCommand = aConnection.CreateCommand();
            //which is to do the sql statement
            aCommand.CommandText = aSQL;
            aCommand.ExecuteNonQuery();

            aFlag = true;
            aConnection.Close();
            return aFlag;
        }

        public bool UpdateRent(int RentId, int DaysUse, string DateStart, string DateEnd, int MileageStart, int MileageEnd, double Total)
        {
            bool aFlag = false;
            string aSQL = "EXEC UpdateRent @RentId= '" + RentId + "', @DaysUse='" + DaysUse + "', @DateStart='" + DateStart + "', @DateEnd='" + DateEnd + "', @MileageStart='" + MileageStart + "', @MileageEnd='" + MileageEnd + "', @Total='" + Total + "' ";
            //oledb is a tool/technology which is the license to the DB
            OleDbConnection aConnection = new OleDbConnection();
            aConnection.ConnectionString = @"Provider=sqloledb;
            Data Source=MSI;Initial Catalog=RentACar;Integrated Security=SSPI";

            aConnection.Open();
            //aCommand tells the database what to do
            OleDbCommand aCommand = aConnection.CreateCommand();
            //which is to do the sql statement
            aCommand.CommandText = aSQL;
            aCommand.ExecuteNonQuery();

            aFlag = true;
            aConnection.Close();
            return aFlag;
        }
    }
}