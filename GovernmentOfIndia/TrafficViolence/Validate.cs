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
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Validate
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<string> listOfRegularExpressionPattern = new List<string>()
        {
            @"^[a-zA-Z][a-zA-Z\\s]+$",   // Charecter 
            @"^[a-zA-Z0-9][a-zA-Z0-9\\s]+$", // caharecter with number
            @"^(?<intro>[A-Z]{2})(?<numeric>\d{2})(?<year>\d{4})(?<tail>\d{7})$", // driver id 
            @"^(?<intro>[A-Z]{2})(?<numeric>\d{2})(?<year>[A-Z]{2})(?<tail>\d{4})$", // vechicle id 
            @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", // date 
            @"^(?<intro>\d{3})([/])((19|20))(?<year>\d{2})$", // case id
            @"^(?<intro>[A-Za-z]{2,4})(?<rank>\d{3})$", // police id
            @"^(?<intro>[A-Za-z ]*)$", // charecter with space
            @"^(?<intro>[A-Za-z0-9 ]*)$" // charecter, digit with space

        };

        private static List<string[]> listOfLicenseType = new List<string[]>()
        {
            // Vehicle Categoarie
            new string[] { "MC", "MCW", "MCWOG", "LMV", "LMV-NT", "LMV-TR", "HMV" },

            // Driving Categoarie
            new string[] { "MCW", "MCWG", "M/CYCL.WG", "MCWOG", "ARNT", "LMV-NT", "LMV-T", "HMV", "ART", "MGV", "MGP", "HGV", "HPV", "HTV", "HZRD", "TR ", "RDRLR" }
        };

        /// <summary>
        /// 
        /// </summary>
        public enum RegularExpressionPattern
        {
            /// <summary>
            /// 
            /// </summary>
            Character,

            /// <summary>
            /// 
            /// </summary>
            CharacterAndDigit,

            /// <summary>
            /// 
            /// </summary>
            DrivingLicenseNumber,

            /// <summary>
            /// 
            /// </summary>
            VehicleLicenseNumber,

            /// <summary>
            /// 
            /// </summary>
            Date,

            /// <summary>
            /// 
            /// </summary>
            CaseId,

            /// <summary>
            /// 
            /// </summary>
            PoliceId,

            /// <summary>
            /// 
            /// </summary>
            CharacterWithSpace,

            /// <summary>
            /// 
            /// </summary>
            CharacterDigitAndSpace

        }

        enum LicenceType
        {
            /// <summary>
            /// 
            /// </summary>
            Vehicle,

            /// <summary>
            /// 
            /// </summary>
            Driving
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expressionPartternKey"></param>
        /// <returns></returns>
        public static bool IsValid(string data, int expressionPartternKey)
        {
            bool isValid = false;
            Regex expression = new Regex(listOfRegularExpressionPattern[expressionPartternKey]);
            if (expression.IsMatch(data))
            {
                isValid = true;
            }

            return isValid;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="licenceListId"></param>
        /// <returns></returns>
        public static bool IsContain(string data, int licenceListId)
        {
            bool isContain = false;
            if (listOfLicenseType[licenceListId].Contains(data.ToUpper()))
            {
                isContain = true;
            }

            return isContain;
        }

        public static bool IsValidInfraction(string[] infractionData)
        {
            bool isValidInfraction = false;
            try
            {
                bool isValidCaseId = IsValid(infractionData[0].Trim(), (int)RegularExpressionPattern.CaseId);
                bool isPoliceId = IsValid(infractionData[1].Trim(), (int)RegularExpressionPattern.PoliceId);
                bool isDate = IsValid(infractionData[2].Trim(), (int)RegularExpressionPattern.Date);
                bool isPlace = IsValid(infractionData[3].Trim(), (int)RegularExpressionPattern.CharacterWithSpace);
                bool isCaseType = IsValid(infractionData[4].Trim(), (int)RegularExpressionPattern.CharacterWithSpace);

                if(isValidCaseId && isPoliceId && isDate && isPlace && isCaseType)
                {
                    isValidInfraction = true;
                }
                else
                {
                    throw new ArgumentException("Invalid datas...");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            return isValidInfraction;
        }

        public static bool IsValidDriver(string[] driverData)
        {
            bool isValidDriver = false;
            try
            {

                bool isLicenseNumber = IsValid(driverData[1].Trim(), (int)RegularExpressionPattern.DrivingLicenseNumber);
                bool isName = IsValid(driverData[2].Trim(), (int)RegularExpressionPattern.Character);
                bool isAddress = IsValid(driverData[3].Trim(), (int)RegularExpressionPattern.CharacterWithSpace);
                bool isCategorie = IsContain(driverData[4].Trim(), (int)LicenceType.Driving);
                bool isDateOfBirth = IsValid(driverData[5].Trim(), (int)RegularExpressionPattern.Date);
                bool isDateOfIssue = IsValid(driverData[6].Trim(), (int)RegularExpressionPattern.Date);

                if (isLicenseNumber && isName && isAddress && isCategorie && isDateOfBirth && isDateOfIssue)
                {
                    isValidDriver = true;
                }
                else
                {
                    throw new ArgumentException("Invalid datas...");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            return isValidDriver;
        }

        public static bool IsValidVehicle(string[] vehicleData)
        {
            bool isValidVehicle = false;
            try
            {
                bool isVehicleNumber = IsValid(vehicleData[1].Trim(), (int)RegularExpressionPattern.VehicleLicenseNumber);
                bool isOwnerName = IsValid(vehicleData[2].Trim(), (int)RegularExpressionPattern.Character);
                bool isAddress = IsValid(vehicleData[3].Trim(), (int)RegularExpressionPattern.CharacterWithSpace);
                bool isCategorie = IsContain(vehicleData[4].Trim(), (int)LicenceType.Vehicle);
                bool isModel = IsValid(vehicleData[5].Trim(), (int)RegularExpressionPattern.CharacterDigitAndSpace);
                bool isExpiryDate = IsValid(vehicleData[6].Trim(), (int)RegularExpressionPattern.Date);

                if (isVehicleNumber && isOwnerName && isAddress && isCategorie && isModel && isExpiryDate)
                {
                    isValidVehicle = true;
                }
                else
                {
                    throw new ArgumentException("Invalid datas...");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

            return isValidVehicle;
        }
    }
}
