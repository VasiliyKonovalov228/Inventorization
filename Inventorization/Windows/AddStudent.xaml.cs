using Inventorization.DB;
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
using System.Windows.Shapes;
using static Inventorization.ClassHelper.EFClass;

namespace Inventorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private DB.Student student = new DB.Student();
        public AddStudent()
        {
            InitializeComponent();
            cbGroup.ItemsSource= context.Group.ToList();
            cbGroup.DisplayMemberPath = "Title";
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

            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {
                MessageBox.Show("Выберите дату рождения");
                return;
            }
            if (cbGroup.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу");
                return;
            }
            
            student.LastName = tbLastName.Text;
            student.Address = tbAddress.Text;
            student.FirstName = tbFirstName.Text;
            student.Patronymic = tbPatronymic.Text;
            student.IDGroup = (cbGroup.SelectedItem as DB.Group).ID;
            context.Student.Add(student);
            context.SaveChanges();
            MessageBox.Show("Студент добавлен");
            Student studentWindow = new Student();
            studentWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Student studentWindow = new Student();
            studentWindow.Show();
            this.Close();
        }
    }
}
