using Inventorization.ClassHelper;
using Inventorization.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static Inventorization.ClassHelper.EFClass;
using static Inventorization.ClassHelper.EmployeeDataContext;

namespace Inventorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var authUser = context.Employee.ToList()
                .Where(i => i.LastName == tbLogin.Text && i.Password == pbPass.Password)
                .FirstOrDefault();

            if (authUser != null)
            {
                EmployeeDataContext.employee = authUser;
                if (authUser.IDPost==1 || authUser.IDPost==2)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else if(authUser.IDPost == 3)
                {
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        
    }
}
