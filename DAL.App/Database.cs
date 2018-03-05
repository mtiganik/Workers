using System;
using System.Collections.Generic;
using System.Text;
using DAL.CSVInput;
using Domain;

namespace DAL.App
{
    // This is where CSV Data will be kept

    public class Database
    {
        public List<Worker> workers { get; set; } = new List<Worker>();
        public List<Department> departments = new List<Department>();
        public List<Position> positions = new List<Position>();

        Department _newDepartment;
        Position _newPosition;

        public void AddWorker(string inputString)
        {
            CSVRepository repo = new CSVRepository(inputString);
            workers.Add(new Worker
            {
                WorkerId = repo.GetWorkerId(),
                FirstName = repo.GetWorkerFirstName(),
                LastName = repo.GetWorkerLastName(),
                ContractFrom = repo.GetWorkerContractFrom(),
                ContractUntil = repo.GetWorkerContractUntil(),
                WorkerContractType = repo.GetWorkerContractType(),
                WorkerDepartment = GetOrCreateDepartment(repo.GetWorkerDepartmentString()),
                WorkerPosition = GetOrCreatePosition(repo.GetWorkerPositionString(), _newDepartment)
                

            });


            Department GetOrCreateDepartment(string DepartmentNameInput)
            {
                foreach (Department dep in departments)
                {
                    if (dep.DepartmentName == DepartmentNameInput)
                    {
                        return dep;
                    }


                }
                _newDepartment = new Department(DepartmentNameInput);
                departments.Add(_newDepartment);
                return _newDepartment;
            }

            Position GetOrCreatePosition(string PositionNameInput, Department PositionDepartment)
            {
                foreach (Position pos in PositionDepartment.Positions)
                {
                    if (pos.PositionName == PositionNameInput)
                    {
                        return pos;
                    }
                }
                _newPosition = new Position(PositionNameInput);
                PositionDepartment.Positions.Add(_newPosition);
                return _newPosition;

            }
        }
    }
}
