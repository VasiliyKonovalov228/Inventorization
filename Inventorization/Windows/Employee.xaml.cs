using Inventorization.DB;
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
using static Inventorization.ClassHelper.EFClass;

namespace Inventorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
            dgEmployee.ItemsSource=context.Employee.ToList();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Изменено");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteEmp = dgEmployee.SelectedItems.Cast<DB.Employee>().ToList();
            
                if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                try
                {
                    
                    context.Employee.RemoveRange(deleteEmp as System.Collections.Generic.IEnumerable<DB.Employee>);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgEmployee.ItemsSource = context.Employee.ToList();
                   
                }
                catch (Exception ex)
                {

                        MessageBox.Show("Ошибка, попробуйте ещё раз");
                }
                }
             
        }
    }
}
