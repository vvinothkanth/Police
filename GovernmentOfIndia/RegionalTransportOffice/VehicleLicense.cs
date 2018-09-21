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
    
    public class VehicleLicense
    {
        private int _number;

        private string _ownerName;

        private string _addess;

        private string _categorie;

        private string _model;

        private string _expiryDate;

        public void SetNumber(int number)
        {
            _number = number;
        }

        public void SetOwnerName(string ownerName)
        {
            _ownerName = ownerName;
        }

        public void SetAddress(string address)
        {
            _addess = address;
        }

        public void SetCategoarie(string categorie)
        {
            _categorie = categorie;
        }

        public void SetModel(string model)
        {
            _model = model;
        }

        public void SetExpiryDate(string expiryDate)
        {
            _expiryDate = expiryDate;
        }

        public int GetNumber()
        {
            return _number;
        }

        public string GetOwnerName( )
        {
            return _ownerName;
        }

        public string GetAddress()
        {
            return _addess;
        }

        public string GetCategoarie()
        {
            return _categorie;
        }

        public string GetModel()
        {
            return _model;
        }

        public string GetExpiryDate()
        {
            return _expiryDate;
        }

    }
}
