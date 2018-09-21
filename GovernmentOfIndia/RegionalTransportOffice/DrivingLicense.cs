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

    public class DrivingLicense
    {
        private int _number;

        private string _name;

        private string _address;

        private string _dateOfBirth;

        private string _dateOfIssue;

        private string _categorie;

        public void SetNumber(int number)
        {
            _number = number;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public void SetDateOfBirth(string dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public void SetDateOfIssue(string dateOfIssue)
        {
            _dateOfIssue = dateOfIssue;
        }

        public void SetCategorie(string categorie)
        {
            _categorie = categorie;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetNumber()
        {
            return _number;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public string GetDateOfIssue()
        {
            return _dateOfIssue;
        }

        public string GetCategorie()
        {
            return _categorie;
        }
    }
}
