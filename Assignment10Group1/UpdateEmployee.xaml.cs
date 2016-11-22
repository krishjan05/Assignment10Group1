using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment10Group1
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
       public Employee emp;
        SQLiteDatabase SQLdb;
        MainWindow m;
        public UpdateEmployee()
        {
            InitializeComponent();
            Console.Write(emp); 
        }

        public void setData()
        {

            txtIDUpdateEmployee.Text = emp.employeeID.ToString();
            txtNameUpdateEmployee.Text = emp.name.ToString();
            txtPositionUpdateEmployee.Text = emp.position.ToString();
            txtRateUpdateEmployee.Text = emp.rate.ToString();
        }

        private void btnSubmitUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            SQLdb = SQLiteDatabase.GetInstance();
            emp.name = txtNameUpdateEmployee.Text;
            emp.position = txtPositionUpdateEmployee.Text;
            emp.rate = int.Parse(txtRateUpdateEmployee.Text);
            SQLdb.UpdateEmployee(emp);
            this.Close();

        }
    }
}
