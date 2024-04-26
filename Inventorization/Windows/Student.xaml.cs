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
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public Student()
        {
            InitializeComponent();
            dgStudent.ItemsSource=context.Student.ToList();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Изменено");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteEmp = dgStudent.SelectedItems.Cast<DB.Student>().ToList();
            
                if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {

                        context.Student.RemoveRange(deleteEmp as System.Collections.Generic.IEnumerable<DB.Student>);
                        context.SaveChanges();
                        MessageBox.Show("Удаленно");
                        dgStudent.ItemsSource = context.Student.ToList();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Ошибка, попробуйте ещё раз");
                    }
                }
            
        }
    }
}
