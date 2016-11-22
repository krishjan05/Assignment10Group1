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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment10Group1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeModel em;
        SQLiteDatabase SQLdb;
        public MainWindow()
        {
            InitializeComponent();
            SQLdb = SQLiteDatabase.GetInstance();
            em = new EmployeeModel();
            DataContext = em;
            em.DisplayEmployee();
            
        }

        private void btnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {         

          
            UpdateEmployee ue = new UpdateEmployee();
            ue.emp = em.DisplaySelectedEmpoyee();
            ue.setData();
            ue.ShowDialog();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.Items.Refresh();
        }
    }
}
