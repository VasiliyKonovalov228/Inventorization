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
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private DB.Employee employee= new DB.Employee();
        public AddEmployee()
        {
            InitializeComponent();
            cbInstitution.ItemsSource=context.Institution.ToList();
            cbInstitution.DisplayMemberPath = "Title";
            cbPost.ItemsSource=context.Post.ToList();
            cbPost.DisplayMemberPath = "Name";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Пароль не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }
            if (cbPost.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность");
                return;
            }
            if (cbInstitution.SelectedItem == null)
            {
                MessageBox.Show("Выберите институт");
                return;
            }
            employee.LastName= tbLastName.Text;
            employee.Password= tbPassword.Text;
            employee.FirstName= tbFirstName.Text;
            employee.Patronymic= tbPatronymic.Text;
            employee.PhoneNumber = tbPhone.Text;
            employee.IDPost = (cbPost.SelectedItem as DB.Post).ID;
            employee.IDInstitution = (cbInstitution.SelectedItem as DB.Institution).ID;
            context.Employee.Add(employee);
            context.SaveChanges();
            MessageBox.Show("Сотрудник добавлен");
            Employee employeeWindow = new Employee();
            employeeWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Close();
        }
    }
}