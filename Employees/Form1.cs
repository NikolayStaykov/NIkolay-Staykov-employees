using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public partial class Form1 : Form
    {
        private List<EmployeRecord> _employeRecords = new List<EmployeRecord>();
        private List<SharedProjectTime> _sharedProjectTimes = new List<SharedProjectTime>();
        public Form1()
        {
            InitializeComponent();
            String line;
            try
            {
                StreamReader streamReader = new StreamReader("DataSource.txt");
                line = streamReader.ReadLine();
                while (line != null)
                {
                    String[] Elements = line.Split(',');
                    if (Elements[3] == " NULL")
                    {
                        this._employeRecords.Add(new EmployeRecord(int.Parse(Elements[0]), int.Parse(Elements[1]), DateTime.Parse(Elements[2]), DateTime.Now));
                    }
                    else
                    {
                        this._employeRecords.Add(new EmployeRecord(int.Parse(Elements[0]), int.Parse(Elements[1]), DateTime.Parse(Elements[2]), DateTime.Parse(Elements[3])));
                    }
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            foreach(EmployeRecord employeRecord in _employeRecords)
            {
                EmployeeRecordsListBox.Items.Add(employeRecord.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < this._employeRecords.Count - 1;i++)
            {
                for(int i2 = i + 1;i2 < this._employeRecords.Count;i2++)
                {
                    if(this._employeRecords[i].GetSharedProjectTime(this._employeRecords[i2]) != null)
                    {
                        this._sharedProjectTimes.Add(this._employeRecords[i].GetSharedProjectTime(this._employeRecords[i2]));
                    }
                }
            }
            /*foreach(SharedProjectTime sharedProjectTime in this._sharedProjectTimes)
            {
                ResultListBox.Items.Add(sharedProjectTime.ToString());
            }*/
            CalculateLongestSharedTime();
        }
        private void CalculateLongestSharedTime()
        {
            TimeSpan Longest = new TimeSpan();
            TimeSpan Current = new TimeSpan();
            int EmployeeID1 = 0;
            int EmployeeID2 = 0;
            for(int i = 0;i < this._sharedProjectTimes.Count;i++)
            {
                Current = this._sharedProjectTimes[i].GetSharedTime();
                for(int i2 = i + 1;i2 < this._sharedProjectTimes.Count;i2++)
                {
                    if(this._sharedProjectTimes[i].GetEmployeeID1() == this._sharedProjectTimes[i2].GetEmployeeID1() && this._sharedProjectTimes[i].GetEmployeeID2() == this._sharedProjectTimes[i2].GetEmployeeID2())
                    {
                        Current = Current.Add(this._sharedProjectTimes[i2].GetSharedTime());
                    }
                    else if(this._sharedProjectTimes[i].GetEmployeeID1() == this._sharedProjectTimes[i2].GetEmployeeID2() && this._sharedProjectTimes[i].GetEmployeeID2() == this._sharedProjectTimes[i2].GetEmployeeID1())
                    {
                        Current = Current.Add(this._sharedProjectTimes[i2].GetSharedTime());
                    }
                }
                if(Current.CompareTo(Longest) > 0)
                {
                    EmployeeID1 = this._sharedProjectTimes[i].GetEmployeeID1();
                    EmployeeID2 = this._sharedProjectTimes[i].GetEmployeeID2();
                    Longest = Current;
                }
            }
            ResultListBox.Items.Add($"Employee {EmployeeID1.ToString()} and employee {EmployeeID2.ToString()} have spent {Longest.TotalDays.ToString()} days working on common projects");
        }
    }
}
