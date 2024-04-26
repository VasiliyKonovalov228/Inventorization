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
    /// Логика взаимодействия для AddChooseEmployee.xaml
    /// </summary>
    public partial class AddChooseEmployee : Window
    {
        private Audience audience = new Audience();
        public AddChooseEmployee()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = context.Employee.ToList();
            cbEmployee.DisplayMemberPath = "LastName";
            cbNumber.ItemsSource = context.Audience.ToList();
            cbNumber.DisplayMemberPath = "Number";
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbNumber.SelectedItem == null)
            {
                MessageBox.Show("Выберите номер аудитории");
                return;
            }
            
            if (cbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            audience.Number =(cbNumber.SelectedItem as DB.Audience).ID;
            audience.IDEmployee = (cbEmployee.SelectedItem as DB.Employee).ID;
           
            context.Audience.Add(audience);
            context.SaveChanges();
            MessageBox.Show("Сотрудник назнаен");
            ChooseEmployee chooseEmployee = new ChooseEmployee();
            chooseEmployee.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChooseEmployee chooseEmployee = new ChooseEmployee();
            chooseEmployee.Show();
            this.Close();
        }
    }
}
