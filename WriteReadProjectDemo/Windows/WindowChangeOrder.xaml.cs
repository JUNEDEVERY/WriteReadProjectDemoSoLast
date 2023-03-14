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

namespace WriteReadProjectDemo
{
    /// <summary>
    /// Логика взаимодействия для WindowChangeOrder.xaml
    /// </summary>
    public partial class WindowChangeOrder : Window
    {
        Order order;
        public WindowChangeOrder(Order order)
        {
            InitializeComponent();
            this.order = order;
            cmbStatus.ItemsSource = db.tbe.statusChange.ToList();
            cmbStatus.SelectedValuePath = "idStatus";
            cmbStatus.DisplayMemberPath = "statusName";
            cmbStatus.SelectedValue = order.OrderStatus;

            dpDeliveryDate.SelectedDate = order.OrderDeliveryDate;
            dpOrderDate.SelectedDate = order.OrderDate;
            cmbChangeOrderPoing.ItemsSource = db.tbe.Point.ToList();
            cmbChangeOrderPoing.SelectedValuePath = "idPickupPoint";
            cmbChangeOrderPoing.DisplayMemberPath = "displayPoint";
            cmbChangeOrderPoing.SelectedValue = order.OrderPickupPoint;
            
            cmbChangeClient.ItemsSource = db.tbe.User.ToList();
            cmbChangeClient.SelectedValuePath = "UserID";
            cmbChangeClient.DisplayMemberPath = "FullName";
            if (order.OrderClientsId != null)
            {
                cmbChangeClient.SelectedValue = order.OrderClientsId;   
            }

            tbCode.Text = order.Code.ToString();
          

        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void changeOrderPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void changeOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.OrderStatus = Convert.ToInt32(cmbStatus.SelectedValue);
                order.OrderDeliveryDate = (DateTime)dpDeliveryDate.SelectedDate;
                order.OrderDate = (DateTime)dpOrderDate.SelectedDate;
                order.OrderPickupPoint = Convert.ToInt32(cmbChangeOrderPoing.SelectedValue);
                order.OrderClientsId = Convert.ToInt32(cmbChangeClient.SelectedValue);
                order.Code = Convert.ToInt32(tbCode.Text);
                db.tbe.SaveChanges();
                MessageBox.Show("Я изменилъ");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
          
        }
    }
}
