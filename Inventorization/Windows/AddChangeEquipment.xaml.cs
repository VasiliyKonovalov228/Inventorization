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
    /// Логика взаимодействия для AddChangeEquipment.xaml
    /// </summary>
    public partial class AddChangeEquipment : Window
    {
        private AudienceEquipment audienceEquipment = new AudienceEquipment();
        public AddChangeEquipment()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = context.Employee.ToList();
            cbEmployee.DisplayMemberPath = "LastName";
            cbEquipment.ItemsSource = context.Equipment.ToList();
            cbEquipment.DisplayMemberPath = "Title";
            cbAudience.ItemsSource = context.Audience.ToList();
            cbAudience.DisplayMemberPath = "Number";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dpDate.Text))
            {
                MessageBox.Show("Выберите дату");
                return;
            }
            if (cbAudience.SelectedItem == null)
            {
                MessageBox.Show("Выберите аудиторию");
                return;
            }
            if (cbEquipment.SelectedItem == null)
            {
                MessageBox.Show("Выберите оборудование");
                return;
            }
            if (cbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            audienceEquipment.IDAudience=(cbAudience.SelectedItem as Audience).ID;
            audienceEquipment.IDEquipment=(cbEquipment.SelectedItem as DB.Equipment).ID;
            audienceEquipment.IDEmployee=(cbEmployee.SelectedItem as DB.Employee).ID;
            audienceEquipment.Date = dpDate.SelectedDate.Value;
            context.AudienceEquipment.Add(audienceEquipment);
            context.SaveChanges();
            MessageBox.Show("Запись добавленa");
            ChangeEquipment changeEquipment = new ChangeEquipment();
            changeEquipment.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeEquipment changeEquipment = new ChangeEquipment();
            changeEquipment.Show();
            this.Close();
        }
    }
}
