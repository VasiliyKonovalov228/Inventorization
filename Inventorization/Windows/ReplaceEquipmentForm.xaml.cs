using Inventorization.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для ReplaceEquipmentForm.xaml
    /// </summary>
    public partial class ReplaceEquipmentForm : Window
    {
        DB.AudienceEquipment selEquipment = context.AudienceEquipment.ToList().Where(i => i.ID==IDChange).FirstOrDefault();
        private AudienceEquipment audienceEquipment = new AudienceEquipment();
        private Repair repair= new Repair();
        private int brokeEquipment;
        public ReplaceEquipmentForm()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = context.Employee.ToList();
            cbEmployee.DisplayMemberPath = "LastName";
            cbEquipment.ItemsSource = context.Equipment.ToList();
            cbEquipment.DisplayMemberPath = "Title";
            cbAudience.ItemsSource = context.Audience.ToList();
            cbAudience.DisplayMemberPath = "Number";

            dpDate.Text = selEquipment.Date.ToString();
            cbAudience.SelectedItem = context.Audience.ToList().Where(i => i.ID == selEquipment.IDAudience).FirstOrDefault();
            cbEmployee.SelectedItem=context.Employee.ToList().Where(i=>i.ID==selEquipment.IDEmployee).FirstOrDefault();
            cbEquipment.SelectedItem = context.Equipment.ToList().Where(i => i.ID == selEquipment.IDEquipment).FirstOrDefault();
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
            if (selEquipment.IDEquipment==(cbEquipment.SelectedItem as DB.Equipment).ID)
            {
                MessageBox.Show("Вы не заменили оборудование");
                return;
            }
            repair.DateStart=DateTime.Now;
            repair.DateEnd=DateTime.Now.AddMonths(1);
            repair.IDEquipment = selEquipment.IDEquipment;
            audienceEquipment.ID = selEquipment.ID;
            audienceEquipment.IDAudience = (cbAudience.SelectedItem as Audience).ID;
            audienceEquipment.IDEquipment = (cbEquipment.SelectedItem as DB.Equipment).ID;
            audienceEquipment.IDEmployee = (cbEmployee.SelectedItem as DB.Employee).ID;
            audienceEquipment.Date = dpDate.SelectedDate.Value;
            context.AudienceEquipment.AddOrUpdate(audienceEquipment);
            context.Repair.Add(repair);
            context.SaveChanges();
            MessageBox.Show("Оборудование заменено");
            ReplaceEquipment replaceEquipment = new ReplaceEquipment();
            replaceEquipment.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReplaceEquipment replaceEquipment = new ReplaceEquipment();
            replaceEquipment.Show();
            this.Close();
        }
    }
}
