using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для ReplaceEquipment.xaml
    /// </summary>
    public partial class ReplaceEquipment : Window
    {
        public ReplaceEquipment()
        {
            InitializeComponent();
            dgChangeEquipment.ItemsSource=context.AudienceEquipment.ToList();
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            if (dgChangeEquipment.SelectedItem!= null)
            {
                TextBlock a = dgChangeEquipment.Columns[0].GetCellContent(dgChangeEquipment.Items[dgChangeEquipment.SelectedIndex]) as TextBlock;
                IDChange = Convert.ToInt32(a.Text);
                ReplaceEquipmentForm replaceEquipmentForm = new ReplaceEquipmentForm();
                replaceEquipmentForm.Show();
                this.Close();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EmployeeWindow employeeWindow =new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
    }
}
