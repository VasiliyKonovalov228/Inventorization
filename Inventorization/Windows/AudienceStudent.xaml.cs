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
    /// Логика взаимодействия для AudienceStudent.xaml
    /// </summary>
    public partial class AudienceStudent : Window
    {
        private DB.AudienceStudent audienceStudent = new DB.AudienceStudent();
        public AudienceStudent()
        {
            InitializeComponent();
            cbAudience.ItemsSource = context.Audience.ToList();
            cbAudience.DisplayMemberPath = "Number";
            cbStudent.ItemsSource = context.Student.ToList();
            cbStudent.DisplayMemberPath = "LastName";
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dpDateStart.Text))
            {
                MessageBox.Show("Выберите дату начала");
                return;
            }
            if (string.IsNullOrWhiteSpace(dpDateEnd.Text))
            {
                MessageBox.Show("Выберите дату конца");
                return;
            }
            if (dpDateEnd.SelectedDate.Value < dpDateStart.SelectedDate.Value)
            {
                MessageBox.Show("Дата начала не может быть раньше даты конца");
                return;
            }
            if (cbStudent.SelectedItem == null)
            {
                MessageBox.Show("Выберите студента");
                return;
            }
            if (cbAudience.SelectedItem == null)
            {
                MessageBox.Show("Выберите аудиторию");
                return;
            }

            audienceStudent.DateStart = dpDateStart.SelectedDate.Value;
            audienceStudent.IDAudience = (cbAudience.SelectedItem as DB.Audience).ID;
            audienceStudent.IDStudent = (cbStudent.SelectedItem as DB.Student).ID;
            audienceStudent.DateEnd = dpDateEnd.SelectedDate.Value;
            audienceStudent.WorkPlace= Convert.ToInt32( tbWorkPlace.Text);
            context.AudienceStudent.Add(audienceStudent);
            context.SaveChanges();
            MessageBox.Show("Запись добавленa");
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
    }
}
