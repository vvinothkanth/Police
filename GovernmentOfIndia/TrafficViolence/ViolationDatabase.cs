
namespace TrafficViolence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ViolationDatabase
    {         

        static void Main(string[] args)
        {
            //bool k = "sdfa".Any(char.IsSymbol);
            
            TrafficViolationRecord v = new TrafficViolationRecord();
            TrafficViolation trafficViolation = new TrafficViolation();
            string[] driverData = new string[] {"", "TN5619951232345", "Ravanan", "Madhurai Main Road", "MCW", "13/07/2018", "23/07/2016"};           
            string[] vehicleData = new string[] { "", "TN23CN5353", "Murugan", "Guindy Main Road", "LMV", "Bajaj R16", "23/07/2025" };
            string[] infractionData = new string[] { "018/2018", "PC101", "06/04/2018", "Mumbai", "Drunk and drive" };

            Driver driver = trafficViolation.CreateDriver(driverData);
            Vehicle vehicle = trafficViolation.CreateVehicle(vehicleData);
            Infraction infraction = trafficViolation.CreateInfraction(infractionData);
            TrafficViolation trafficViolations = v.CreateTrafficViolation(driver, vehicle, infraction);

            string filePath = @"C:\Users\vinothkanth\Desktop\GovernmentOfIndia\TrafficViolence\TrafficViolationRecord.csv";
            for (int i = 0; i < 10; i++)
            {
             // v.StoreTheDataIntoCsvFile(trafficViolation, filePath);                
            }
                        
            List<string> rawTrafficViolationData = v.LoadCsvFile(filePath);

            List<string[]> listOfViolationData = v.SplitThaData(rawTrafficViolationData, '#');

            List<TrafficViolation> listOfTrafficViolation = v.CreateTrafficViolationList(listOfViolationData);


            foreach (var item in listOfTrafficViolation)
            {
                //Console.WriteLine("{0}, {1}, {2}, {3}", item.GetDriver().GetName(), item.GetVehicle().GetNumber(), item.GetInfraction().GetPoliceId(), item.GetInfraction().GetCaseType());
            }

            List<TrafficViolation> infractionOfDriver =  v.GetDriverInfractions("TN5619951232345", listOfTrafficViolation);
            List<TrafficViolation> infractionOfDriver1 = v.GetTicktedByPolice("PC101", listOfTrafficViolation);
            List<TrafficViolation> infractionOfDriver2 = v.GetVehicleCategoarieInfractions("HMV", listOfTrafficViolation);

            foreach (var item in infractionOfDriver)
            {
               // Console.WriteLine(item.GetInfraction().GetDataIntoCsvFormate());
            }

            foreach (var item in infractionOfDriver1)
            {
                //Console.WriteLine(item.GetVehicle().GetDataIntoCsvFormate());
            }

            foreach (var item in infractionOfDriver2)
            {
                Console.WriteLine("{0} - {1}", item.GetVehicle().GetDataIntoCsvFormate(),item.GetInfraction().GetDataIntoCsvFormate());
            }
            Console.ReadKey();
        }


    }
}
