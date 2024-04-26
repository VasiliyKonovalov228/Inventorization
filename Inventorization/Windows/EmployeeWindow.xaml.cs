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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            tbFI.Text = EmployeeDataContext.employee.FirstName.ToString() + " " + EmployeeDataContext.employee.LastName.ToString() + " / " + EmployeeDataContext.employee.Post.Name.ToString();
       
        }

        private void btnRepairEquipment_Click(object sender, RoutedEventArgs e)
        {
            ReplaceEquipment replaceEquipment = new ReplaceEquipment();
            replaceEquipment.Show();
            this.Close();
        }

        private void btnChooseStudent_Click(object sender, RoutedEventArgs e)
        {
            AudienceStudent audienceStudent = new AudienceStudent();
            audienceStudent.Show();
            this.Close();
        }
    }
}
