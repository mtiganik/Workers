using System;
using System.Collections.Generic;
using System.Globalization;
using Domain;

namespace DAL.CSVInput
{
    public class CSVRepository
    {
        private readonly string _inputString;
        private bool _isContractUntilSet;
        private DateTime _contractFrom;
        private DateTime _contractUntil; 

        public CSVRepository(string inputString)
        {
            _inputString = inputString;
        }

        public int GetWorkerId()
        {
            return Convert.ToInt32(_inputString.Split(',')[0]);
        }

        public string GetWorkerFirstName()
        {
            return _inputString.Split(',')[1];
        }

        public string GetWorkerLastName()
        {
            return _inputString.Split(',')[2];
        }

        public DateTime GetWorkerContractFrom()
        {
            _contractFrom = DateTime.ParseExact(_inputString.Split(',')[3], "dd.MM.yyyy", CultureInfo.CurrentCulture);
            return _contractFrom;
        }

        public DateTime GetWorkerContractUntil()
        {

            _isContractUntilSet = DateTime.TryParseExact(_inputString.Split(',')[4], "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out _contractUntil);
            return _contractUntil;
        }
        
        public ContractType GetWorkerContractType()
        {

            if (_contractFrom > DateTime.Now)
            {
                return ContractType.ValidInFuture;
            }
            if ((_contractFrom < DateTime.Now && _contractUntil > DateTime.Now) || _contractUntil.Year == 0001)
            {
                return ContractType.Valid;
            }
            else if (_contractUntil < DateTime.Now)
            {
                return ContractType.Invalid;
            }
            else return ContractType.ErrorInInput;
        }

        public string GetWorkerDepartmentString()
        {
            return (_inputString.Split(',')[5]);
        }

        public string GetWorkerPositionString()
        {
            return (_inputString.Split(',')[6]);
        }

    }
}



