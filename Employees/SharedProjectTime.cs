using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class SharedProjectTime
    {
        private int _employeeID1;
        private int _employeeID2;
        private int _projectID;
        private TimeSpan _sharedTime;
        public SharedProjectTime(int EmployeeID1,int EmployeeID2, int ProjectID, TimeSpan SharedTime)
        {
            _employeeID1 = EmployeeID1;
            _employeeID2 = EmployeeID2;
            _projectID = ProjectID;
            _sharedTime = SharedTime;
        }
        public int GetEmployeeID1()
        {
            return this._employeeID1;
        }
        public int GetEmployeeID2()
        {
            return this._employeeID2;
        }
        public int GetProjectID()
        {
            return this._projectID;
        }
        public TimeSpan GetSharedTime()
        {
            return this._sharedTime;
        }
        public override string ToString()
        {
            return $"ID1:{this._employeeID1.ToString()},ID2:{this._employeeID2},Project:{this._projectID},Time:{this._sharedTime.ToString()}";
        }
    }
}
