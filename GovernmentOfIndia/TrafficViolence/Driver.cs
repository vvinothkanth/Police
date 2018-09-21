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

    /// <summary>
    /// 
    /// </summary>
    public class Driver
    {
        private string _licenseNumber;

        private string _name;

        private string _address;

        private string _dateOfBirth;

        private string _dateOfIssue;

        private string _categorie;

        public void SetLicenseNumber(string licenseNumber)
        {
            _licenseNumber = licenseNumber;
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

        public string GetLicenseNumber()
        {
            return _licenseNumber;
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

        public virtual string GetDataIntoCsvFormate()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", _licenseNumber, _name, _address, _categorie, _dateOfBirth, _dateOfIssue);
        }
    }
}
