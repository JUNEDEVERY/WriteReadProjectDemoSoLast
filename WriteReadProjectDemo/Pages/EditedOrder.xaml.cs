using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WriteReadProjectDemo
{
    /// <summary>
    /// Логика взаимодействия для EditedOrder.xaml
    /// </summary>
    public partial class EditedOrder : Page
    {



        List<Product> ORDERZ = new List<Product>();
        public static List<string> orders = new List<string>();
        List<SummClass> order = new List<SummClass>();
        List<SaleClass> s = new List<SaleClass>();
        public EditedOrder()
        {
            InitializeComponent();
            lvOrderEdited.ItemsSource = db.tbe.Order.ToList();

         
            double summa1 = 0;
            double summa2 = 0;
            double procent = 0;
            foreach (var item in db.tbe.Order)
            {
                SaleClass s1 = new SaleClass();
                foreach (var item1 in db.tbe.OrderProduct.Where(x => x.OrderID == item.OrderID).ToList())
                {

                    summa1 += (int)item1.Product.ProductCost * item1.Count; // просто цена

                    summa2 += (int)(item1.Product.ProductCost - (item1.Product.ProductCost * item1.Product.ProductDiscountAmount / 100)) * item1.Count; // с учетом скидки


                }
                procent = (summa1 - summa2) / (summa1 / 100);
                s1.Sale = procent;
                s.Add(s1);

            }

            foreach (var item in db.tbe.Order)
            {
                SummClass summ = new SummClass();
                int summa = 0;
                summ.order = item;
                foreach (OrderProduct ord in db.tbe.OrderProduct)
                {
                    if (ord.OrderID == item.OrderID)
                    {
                        summa += (int)ord.Product.ProductCost * ord.Count;

                    }

                }
                summ.Summa = summa;
                order.Add(summ);
                lvOrderEdited.ItemsSource = order;

            }





        }

        private void tbSostavZakaza_Loaded(object sender, RoutedEventArgs e)
        {
        }
        public static bool quantinyinStock;
        private void border_Loaded(object sender, RoutedEventArgs e)
        {
            Border border = sender as Border;
            int id = Convert.ToInt32(border.Uid);

            List<OrderProduct> orderProduct = db.tbe.OrderProduct.Where(x => x.OrderID == id).ToList();
            foreach (var item in orderProduct)
            {

                Product product1 = db.tbe.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);
                if (item.Product.ProductQuantityInStock > 3)
                {
                    quantinyinStock = true;

                }
                else
                {
                    quantinyinStock = false;
                    break;

                }

            }
            if (quantinyinStock)
            {
                SolidColorBrush scb = (SolidColorBrush)new BrushConverter().ConvertFromString("#20b2aa");
                border.BorderBrush = scb;

            }
            else
            {
                SolidColorBrush scb1 = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8c00");
                border.BorderBrush = scb1;

            }
        }
        private void tbSostavZakaza_Loaded_1(object sender, RoutedEventArgs e)
        {

            string nameOrderProduct = "";
            TextBlock textBlock = sender as TextBlock;
            int id = Convert.ToInt32(textBlock.Uid);
            List<OrderProduct> orderProduct = db.tbe.OrderProduct.Where(x => x.OrderID == id).ToList();
            foreach (var item in orderProduct)
            {

                Product product1 = db.tbe.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);

                nameOrderProduct += product1.ProductName + $"({item.Count} шт.) ";


            }
            textBlock.Text = "Состав заказа >  " + nameOrderProduct;

        }

        private void tbSummZakaza_Loaded(object sender, RoutedEventArgs e)
        {

            int summa = 0;
            TextBlock textBlock = sender as TextBlock;
            int id = Convert.ToInt32(textBlock.Uid);
            List<OrderProduct> orderProduct = db.tbe.OrderProduct.Where(x => x.OrderID == id).ToList();
            foreach (var item in orderProduct)
            {

                Product product1 = db.tbe.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);

                summa += (int)product1.ProductCost * item.Count;


            }
            //orderFIltresSumm = summa;
            textBlock.Text = "Сумма заказа > " + Convert.ToString(summa);
        }

        public static List<int> orderFIltresSumm;
        private void tbAllSale_Loaded(object sender, RoutedEventArgs e)
        {
            double summa = 0;
            double summa1 = 0;
            double procent = 0;
            TextBlock textBlock = sender as TextBlock;
            int id = Convert.ToInt32(textBlock.Uid);
            if (textBlock.Uid != null)
            {
                List<OrderProduct> orderProduct = db.tbe.OrderProduct.Where(x => x.OrderID == id).ToList();
                foreach (var item in orderProduct)
                {
                    Product product1 = db.tbe.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);
                    summa += (int)product1.ProductCost * item.Count; // просто цена

                    summa1 += (int)(product1.ProductCost - (product1.ProductCost * product1.ProductDiscountAmount / 100)) * item.Count; // с учетом скидки


                }
                procent = (summa - summa1) / (summa / 100);
                textBlock.Text = "Сумма с учетом скидки > " + summa1.ToString() + $"({procent} %) ";
            }
            else
            {
                textBlock.Text = "";
            }
        }




        private void btnChangeOrder_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Uid);
            Order order = db.tbe.Order.FirstOrDefault(x => x.OrderID == id);
            WindowChangeOrderADM orderADM = new WindowChangeOrderADM(order);
            orderADM.Show();

            //NavigationService.Navigate(new WindowChangeOrderADM(order));

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public void filtres()
        {

            List<SummClass> order = new List<SummClass>();

            foreach (var item in db.tbe.Order)
            {
                SummClass summ = new SummClass();
                int summa = 0;
                summ.order = item;
                foreach (OrderProduct ord in db.tbe.OrderProduct)
                {
                    if (ord.OrderID == item.OrderID)
                    {
                        summa += (int)ord.Product.ProductCost * ord.Count;

                    }

                }
                summ.Summa = summa;
                order.Add(summ);

            }

            List<SaleClass> s = new List<SaleClass>();
            double summa1 = 0;
            double summa2 = 0;
            double procent = 0;
            foreach (var item in db.tbe.Order)
            {
                SaleClass s1 = new SaleClass();
                foreach (var item1 in db.tbe.OrderProduct.Where(x => x.OrderID == item.OrderID).ToList())
                {

                    summa1 += (int)item1.Product.ProductCost * item1.Count; // просто цена

                    summa2 += (int)(item1.Product.ProductCost - (item1.Product.ProductCost * item1.Product.ProductDiscountAmount / 100)) * item1.Count; // с учетом скидки

                   
                }
                procent = (summa1 - summa2) / (summa1 / 100);
                s1.Sale = procent;
                s.Add(s1);

            }



            //orderFIltresSumm
            if (cmbFiltres != null)
            {
                if (cmbFiltres.SelectedValue != null)
                {
                    ComboBoxItem cmb1 = (ComboBoxItem)cmbFiltres.SelectedItem;
                    switch (cmb1.Content)
                    {
                        case "0-10%":
                            {
                                s = s.Where(x => x.Sale >= 0 && x.Sale < 10).ToList();
                                break;
                            }
                        case "11-14%":
                            {
                                s = s.Where(x => x.Sale >= 11 && x.Sale <= 14).ToList();
                                break;
                            }
                        case "15% и более":
                            {
                                s = s.Where(x => x.Sale > 15).ToList();
                                break;
                            }
                    }
                }
            }
            //if (cmbSorted != null)
            //{
            //    if (cmbSorted.SelectedValue != null)
            //    {
            //        ComboBoxItem cmb = (ComboBoxItem)cmbSorted.SelectedItem;
            //        switch (cmb.Content)
            //        {
            //            case "По возрастанию":
            //                {
            //                    order = order.OrderBy(x => x.Summa).ToList();
            //                    break;
            //                }
            //            case "По убыванию":
            //                {
            //                    order = order.OrderByDescending(x => x.Summa).ToList();

            //                    break;
            //                }
            //        }
            //    }
            //}


            lvOrderEdited.ItemsSource = s;

        }
        private void cmbSorted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtres();
        }

        private void btnOutFiltres_Click(object sender, RoutedEventArgs e)
        {
            List<SummClass> order = new List<SummClass>();

            cmbSorted.SelectedValue = order;

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Uid);
            Order order = db.tbe.Order.FirstOrDefault(x => x.OrderID == id);
            WindowChangeOrder orderchange = new WindowChangeOrder(order);
            orderchange.Show();
        }
    }
}
