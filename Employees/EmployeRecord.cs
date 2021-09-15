using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class EmployeRecord
    {
        private int _employeeID;
        private int _projectID;
        private DateTime _startDate;
        private DateTime _endDate;

        public EmployeRecord(int EmployeeID,int ProjectID, DateTime StartDate, DateTime EndDate)
        {
            this._employeeID = EmployeeID;
            this._projectID = ProjectID;
            this._startDate = StartDate;
            this._endDate = EndDate;
        }
        public int GetEmployeeID()
        {
            return this._employeeID;
        }
        public int GetProjectID()
        {
            return this._projectID;
        }
        public DateTime GetStartDate()
        {
            return this._startDate;
        }
        public DateTime GetEndDate()
        {
            return this._endDate;
        }
        public SharedProjectTime GetSharedProjectTime(EmployeRecord other)
        {
            if((this._employeeID == other.GetEmployeeID()) || (this._projectID != other.GetProjectID()))
            {
                return null;// new TimeSpan();
            }
            DateTime SharedStart;
            DateTime SharedEnd;
            if (this._startDate.CompareTo(other.GetStartDate()) > 0)
            {
                SharedStart = this._startDate;
            }
            else
            {
                SharedStart = other.GetStartDate();
            }
            if(this._endDate.CompareTo(other.GetEndDate()) < 0)
            {
                SharedEnd = this._endDate;
            }
            else
            {
                SharedEnd = other.GetEndDate();
            }
            if(SharedStart.CompareTo(SharedEnd) > 0)
            {
                return null;
            }
            else
            {
                return new SharedProjectTime(this._employeeID,other.GetEmployeeID(),this._projectID,SharedEnd.Subtract(SharedStart));
            }
        }
        public override String ToString()
        {
            return $"Employee ID: {this._employeeID.ToString()}, Project ID:{this._projectID.ToString()}, Start Date: {this._startDate.Date.ToString()}, End Date: {this._endDate.Date.ToString()}";
        }
    }
}
