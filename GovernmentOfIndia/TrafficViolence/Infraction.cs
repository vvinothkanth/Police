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
    public class Infraction
    {
        private string _caseId;

        private string _policeId;

        private string _date;

        private string _location;

        private string _caseType;

        public void SetCaseId(string caseId)
        {
            _caseId = caseId;
        }

        public void SetPoliceId(string policeId)
        {
            _policeId = policeId;
        }

        public void SetDate(string date)
        {
            _date = date;
        }

        public void SetPlace(string location)
        {
            _location = location;
        }

        public void SetCaseType(string caseType)
        {
            _caseType = caseType;
        }

        public string GetCaseId()
        {
            return _caseId;
        }

        public string GetPoliceId()
        {
            return _policeId;
        }

        public string GetDate()
        {
            return _date;
        }

        public string GetPlace()
        {
            return _location;
        }

        public string GetCaseType()
        {
            return _caseType;
        }

        public virtual string GetDataIntoCsvFormate()
        {
            return string.Format("{0},{1},{2},{3},{4}", _caseId, _policeId, _date, _location, _caseType) ;            
        }

    }
}
