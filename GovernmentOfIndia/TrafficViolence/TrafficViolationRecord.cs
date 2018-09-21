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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class TrafficViolationRecord
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="vehicle"></param>
        /// <param name="infraction"></param>
        /// <returns></returns>
        public virtual TrafficViolation CreateTrafficViolation(Driver driver, Vehicle vehicle, Infraction infraction)
        {
            TrafficViolation trafficViolation = new TrafficViolation();
            try
            {
                trafficViolation.SetDriver(driver);
                trafficViolation.SetVehicle(vehicle);
                trafficViolation.SetInfraction(infraction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return trafficViolation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trafficViolations"></param>
        /// <returns></returns>
        public virtual List<TrafficViolation> CreateTrafficViolationList(List<string[]> trafficViolations)
        {
            List<TrafficViolation> listOfTrafficViolation = new List<TrafficViolation>();
            try
            {
                TrafficViolation trafficViolation = new TrafficViolation();
                foreach (var violation in trafficViolations)
                {
                    Infraction infractions = trafficViolation.CreateInfraction(SplitTheData(violation[0], ','));
                    Driver drivers = trafficViolation.CreateDriver(SplitTheData(violation[1], ','));
                    Vehicle vehicles = trafficViolation.CreateVehicle(SplitTheData(violation[2], ','));
                    TrafficViolation trafficCasess = CreateTrafficViolation(drivers, vehicles, infractions);
                    listOfTrafficViolation.Add(trafficCasess);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message.ToString());
            }

            return listOfTrafficViolation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirver"></param>
        /// <param name="vehicle"></param>
        /// <param name="infraction"></param>
        /// <param name="filePath"></param>
        public void WriteData(string dirver, string vehicle, string infraction, string filePath)
        {
            try
            {
                string violationData = string.Format("{0},#,{1},#,{2}", infraction.ToUpper(), dirver.ToUpper(), vehicle.ToUpper());
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(violationData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trafficViolation"></param>
        /// <param name="filePath"></param>
        public void StoreTheDataIntoCsvFile(TrafficViolation trafficViolation, string filePath)
        {
            string driver = trafficViolation.GetDriver().GetDataIntoCsvFormate();
            string vehicle = trafficViolation.GetVehicle().GetDataIntoCsvFormate();
            string infraction = trafficViolation.GetInfraction().GetDataIntoCsvFormate();
            WriteData(driver, vehicle, infraction, filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> LoadCsvFile(string filePath)
        {
            List<string> searchList = new List<string>();
            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    searchList.Add(line.ToUpper());
                }
                if (searchList.Count == 0)
                {
                    throw new Exception("File is empty...");
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message.ToString());
            }

            return searchList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="splitedBy"></param>
        /// <returns></returns>
        public static string[] SplitTheData(string rawData, char splitedBy)
        {
            string[] splitedData = rawData.Split(splitedBy);
            return splitedData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="splitBy"></param>
        /// <returns></returns>
        public List<string[]> SplitThaData(List<string> rawData, char splitBy)
        {
            List<string[]> trafficCaseDatas = new List<string[]>();
            foreach (var trafficCase in rawData)
            {
                trafficCaseDatas.Add(SplitTheData(trafficCase, splitBy));
            }

            return trafficCaseDatas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverLicenseNo"></param>
        /// <param name="trafficViolations"></param>
        /// <returns></returns>
        public List<TrafficViolation> GetDriverInfractions(string driverLicenseNo , List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> infractionsOfDriver = new List<TrafficViolation>();
            try
            {
                var data = from infraction in trafficViolations where infraction.GetDriver().GetLicenseNumber().Trim() == driverLicenseNo.ToUpper() select infraction;
                infractionsOfDriver = data.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return infractionsOfDriver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverLicenseNo"></param>
        /// <param name="vehicleLicenseNo"></param>
        /// <param name="trafficViolations"></param>
        /// <returns></returns>
        public List<TrafficViolation> GetDriverInfractions(string driverLicenseNo, string vehicleLicenseNo,List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> infractionsOfDriver = new List<TrafficViolation>();
            try
            {
                
                var data = from infraction in trafficViolations where infraction.GetDriver().GetLicenseNumber().Trim() == driverLicenseNo.ToUpper() && infraction.GetVehicle().GetNumber() == vehicleLicenseNo.ToUpper() select infraction;
                infractionsOfDriver = data.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return infractionsOfDriver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleCategoarie"></param>
        /// <param name="trafficViolations"></param>
        /// <returns></returns>
        public List<TrafficViolation> GetVehicleCategoarieInfractions(string vehicleCategoarie, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> infractionsOfDriver = new List<TrafficViolation>();
            try
            {
                var data = from infraction in trafficViolations where infraction.GetVehicle().GetCategoarie().Trim() == vehicleCategoarie.ToUpper() select infraction;
                infractionsOfDriver = data.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return infractionsOfDriver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="policeId"></param>
        /// <param name="trafficViolations"></param>
        /// <returns></returns>
        public List<TrafficViolation> GetTicktedByPolice(string policeId, List<TrafficViolation> trafficViolations)
        {
            List<TrafficViolation> infractionsOfDriver = new List<TrafficViolation>();
            try
            {
                var data = from infraction in trafficViolations where infraction.GetInfraction().GetPoliceId().Trim() == policeId.ToUpper() select infraction;
                infractionsOfDriver = data.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return infractionsOfDriver;
        }
    }

}
