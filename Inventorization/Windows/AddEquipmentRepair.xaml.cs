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
    /// Логика взаимодействия для AddEquipmentRepair.xaml
    /// </summary>
    public partial class AddEquipmentRepair : Window
    {
        private Repair repair = new Repair();
        public AddEquipmentRepair()
        {
            InitializeComponent();
            cbEquipment.ItemsSource= context.Equipment.ToList();
            cbEquipment.DisplayMemberPath = "Title";
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
             if (dpDateEnd.SelectedDate.Value<dpDateStart.SelectedDate.Value)
            {
                MessageBox.Show("Дата начала не может быть раньше даты конца");
                return;
            }
            if (cbEquipment.SelectedItem == null)
            {
                MessageBox.Show("Выберите оборудование");
                return;
            }
            
            repair.DateStart = dpDateStart.SelectedDate.Value;
            repair.IDEquipment = (cbEquipment.SelectedItem as DB.Equipment).ID;
            repair.Description = tbDescription.Text;
            repair.DateEnd = dpDateEnd.SelectedDate.Value;
            context.Repair.Add(repair);
            context.SaveChanges();
            MessageBox.Show("Запись добавленa");
            EquipmentRepair equipmentRepair = new EquipmentRepair();
            equipmentRepair.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EquipmentRepair equipmentRepair = new EquipmentRepair();
            equipmentRepair.Show();
            this.Close();
        }
    }
}
