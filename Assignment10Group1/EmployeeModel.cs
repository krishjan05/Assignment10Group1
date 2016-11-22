using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment10Group1
{
    class EmployeeModel : INotifyPropertyChanged
    {
        SQLiteDatabase SQLdb;
        public List<Employee> employee
        {
            get { return _employee; }
            set { _employee = value; OnPropertyChanged(); }
        }private List<Employee> _employee;

        public Employee selectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                if(_selectedEmployee != value)
                {
                    OnPropertyChanged();
                }
            }
        }private Employee _selectedEmployee;


        public void DisplayEmployee()
        {
            SQLdb = SQLiteDatabase.GetInstance();
            _employee = SQLdb.GetEmployees();
        }
        public Employee DisplaySelectedEmpoyee()
        {
            SQLdb = SQLiteDatabase.GetInstance();
            //_selectedEmployee = SQLdb.GetEmployee();
            selectedEmployee = _selectedEmployee;
            return selectedEmployee;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
