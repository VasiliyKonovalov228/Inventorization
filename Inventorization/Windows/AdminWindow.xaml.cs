using Inventorization.ClassHelper;
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
using static Inventorization.ClassHelper.EmployeeDataContext;

namespace Inventorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            tbFI.Text = EmployeeDataContext.employee.FirstName.ToString() + " " + EmployeeDataContext.employee.LastName.ToString() + " / " + EmployeeDataContext.employee.Post.Name.ToString();
        }

        private void btnEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
            this.Close();
        }

        private void btnChangeEquip_Click(object sender, RoutedEventArgs e)
        {
            ChangeEquipment changeEquipment = new ChangeEquipment();
            changeEquipment.Show();
            this.Close();
        }

        private void btnEquipOnRepair_Click(object sender, RoutedEventArgs e)
        {
            EquipmentRepair equipmentRepair = new EquipmentRepair();
            equipmentRepair.Show();
            this.Close();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.Show();
            this.Close();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Close();
        }

        private void btnChooseEmployee_Click(object sender, RoutedEventArgs e)
        {
            ChooseEmployee chooseEmployee = new ChooseEmployee();
            chooseEmployee.Show();
            this.Close();
        }
    }
}
