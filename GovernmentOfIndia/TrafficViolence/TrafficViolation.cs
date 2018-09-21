//-----------------------------------------------
//  Problem Title : Trafic violence
//  Author        : Vinoth Kanth V
//  Date          : 19 / 9 / 2018
//  
//
//
//-----------------------------------------------

namespace TrafficViolence
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class TrafficViolation
    {
        private Driver _driver;

        private Vehicle _vehicle;

        private Infraction _infraction;

        public void SetDriver(Driver driver)
        {
            _driver = driver;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void SetInfraction(Infraction infraction)
        {
            _infraction = infraction;
        }

        public Driver GetDriver()
        {
            return _driver;
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        public Infraction GetInfraction()
        {
            return _infraction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infractionData"></param>
        /// <returns></returns>
        public virtual Infraction CreateInfraction(string[] infractionData)
        {
            Infraction infraction = new Infraction();
            try
            {
                if (Validate.IsValidInfraction(infractionData))
                {
                    infraction.SetCaseId(infractionData[0].Trim());
                    infraction.SetPoliceId(infractionData[1].Trim());
                    infraction.SetDate(infractionData[2].Trim());
                    infraction.SetPlace(infractionData[3].Trim());
                    infraction.SetCaseType(infractionData[4].Trim());
                }
                else
                {
                    throw new Exception("Not Valid Data");
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message.ToString());
            }

            return infraction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverData"></param>
        /// <returns></returns>
        public virtual Driver CreateDriver(string[] driverData)
        {
            Driver driver = new Driver();
            try
            {
                if (Validate.IsValidDriver(driverData))
                {
                    driver.SetLicenseNumber(driverData[1].Trim());
                    driver.SetName(driverData[2].Trim());
                    driver.SetAddress(driverData[3].Trim());
                    driver.SetCategorie(driverData[4].Trim());
                    driver.SetDateOfBirth(driverData[5].Trim());
                    driver.SetDateOfIssue(driverData[6].Trim());
                }
                else
                {
                    throw new Exception("Not Valid Data");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message.ToString());
            }

            return driver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleData"></param>
        /// <returns></returns>
        public virtual Vehicle CreateVehicle(string[] vehicleData)
        {
            Vehicle vehicle = new Vehicle();
            try
            {
                if (Validate.IsValidVehicle(vehicleData))
                {
                    vehicle.SetNumber(vehicleData[1].Trim());
                    vehicle.SetOwnerName(vehicleData[2].Trim());
                    vehicle.SetAddress(vehicleData[3].Trim());
                    vehicle.SetCategoarie(vehicleData[4].Trim());
                    vehicle.SetModel(vehicleData[5].Trim());
                    vehicle.SetExpiryDate(vehicleData[6].Trim());
                }
                else
                {
                    throw new Exception("Not Valid Data");
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message.ToString());
            }

            return vehicle;
        }
    }
}
