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
    /// Логика взаимодействия для AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        private DB.Equipment equipment = new DB.Equipment();
        public AddEquipment()
        {
            InitializeComponent();
            cbManufacturer.ItemsSource=context.Manufacturer.ToList();
            cbManufacturer.DisplayMemberPath = "Title";
            cbType.ItemsSource = context.Type.ToList();
            cbType.DisplayMemberPath = "Ttile";
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                MessageBox.Show("Цена не может быть пустой");
                return;
            }
            if (cbManufacturer.SelectedItem == null)
            {
                MessageBox.Show("Выберите производителя");
                return;
            }
            if (cbType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип");
                return;
            }
            if (cbWorked.SelectedItem == null)
            {
                MessageBox.Show("Выберите рабочее состояние");
                return;
            }
            equipment.Title= tbTitle.Text;
            equipment.Price = Convert.ToDecimal(tbPrice.Text);
            equipment.Description=tbDescription.Text;
            equipment.IDManufacturer = (cbManufacturer.SelectedItem as DB.Manufacturer).ID;
            equipment.IDType = (cbType.SelectedItem as DB.Type).ID;
            if (cbWorked.SelectedIndex==0)
            {
                equipment.Worked = true;
            }
            else
            {
                equipment.Worked = false;
            }
            context.Equipment.Add(equipment);
            context.SaveChanges();
            MessageBox.Show("Оорудование добавленo");
            Equipment equipmentWindow = new Equipment();
            equipmentWindow.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Equipment equipmentWindow = new Equipment();
            equipmentWindow.Show();
            this.Close();
        }
    }
}
