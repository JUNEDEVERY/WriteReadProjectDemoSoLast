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
    /// Логика взаимодействия для AddProductAdmin.xaml
    /// </summary>
    public partial class AddProductAdmin : Window
    {
        public AddProductAdmin()
        {
            InitializeComponent();
            cmbCategory.ItemsSource = db.tbe.ProductCategory.ToList();
            cmbCategory.SelectedValuePath = "ProductCategoryID";
            cmbCategory.DisplayMemberPath = "ProductCategory";

            cmbManufacturer.ItemsSource = db.tbe.manufacture.ToList();
            cmbManufacturer.SelectedValuePath = "idManufacture";
            cmbManufacturer.DisplayMemberPath = "manufactureName";

            cmbEdIzm.ItemsSource = db.tbe.edIzm.ToList();
            cmbCategory.SelectedValuePath = "idEdIzm";
            cmbCategory.DisplayMemberPath = "edizm";
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            if (!string.IsNullOrEmpty(tbArcticle.Text))
            {
                if (!string.IsNullOrEmpty(tbNameProduct.Text))
                {
                    if ()
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните артикль");
            }
        }
    }
}
