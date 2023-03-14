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
using System.Windows.Navigation;
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
            cmbCategory.DisplayMemberPath = "ProductCategoryName";

            cmbManufacturer.ItemsSource = db.tbe.manufacture.ToList();
            cmbManufacturer.SelectedValuePath = "idManufacture";
            cmbManufacturer.DisplayMemberPath = "manufactureName";

            cmbEdIzm.ItemsSource = db.tbe.edIzm.ToList();
            cmbEdIzm.SelectedValuePath = "idEdIzm";
            cmbEdIzm.DisplayMemberPath = "edenicaizm";

            cmbSupplier.ItemsSource = db.tbe.supplier.ToList();
            cmbSupplier.SelectedValuePath = "idSupplier";
            cmbSupplier.DisplayMemberPath = "supplierName";
            addProduct.Background = (SolidColorBrush)new SolidColorBrush(Color.FromRgb(73, 140, 81));
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbArcticle.Text))
            {
                if (!string.IsNullOrEmpty(tbNameProduct.Text))
                {
                    if (!string.IsNullOrEmpty(tbDescriptionProduct.Text))
                    {

                        if (cmbCategory.SelectedItem != null)
                        {
                            if (cmbCategory != null)
                            {
                                if (cmbManufacturer.SelectedItem != null)
                                {
                                    if (cmbManufacturer != null)
                                    {
                                        if (!string.IsNullOrEmpty(tbCost.Text))
                                        {
                                            if (!string.IsNullOrEmpty(tbMaxDiscount.Text))
                                            {
                                                if (!string.IsNullOrEmpty(tbSale.Text))
                                                {
                                                    if (!string.IsNullOrEmpty(tbQuantity.Text))
                                                    {
                                                        if (cmbEdIzm != null)
                                                        {

                                                            if (cmbEdIzm.SelectedItem != null)
                                                            {
                                                                if (cmbSupplier.SelectedItem != null)
                                                                {
                                                                    if (cmbSupplier != null)
                                                                    {
                                                                        Product product = new Product();
                                                                        product.ProductArticleNumber = tbArcticle.Text;
                                                                        product.ProductName = tbNameProduct.Text;
                                                                        product.ProductDescription = tbDescriptionProduct.Text;
                                                                        product.ProductCategory = Convert.ToInt32(cmbCategory.SelectedValue);
                                                                        product.ProductManufacturer = Convert.ToInt32(cmbManufacturer.SelectedValue);
                                                                        product.ProductCost = Convert.ToDecimal(tbCost.Text);
                                                                        product.ProductDiscountAmount = Convert.ToInt32(tbSale.Text);
                                                                        product.ProductQuantityInStock = Convert.ToInt32(tbQuantity.Text);
                                                                        product.ProductStatus = null;
                                                                        product.idEdIzm = Convert.ToInt32(cmbEdIzm.SelectedValue);
                                                                        product.maxDiscount = Convert.ToInt32(tbMaxDiscount.Text);
                                                                        product.idSupplier = Convert.ToInt32(cmbSupplier.SelectedValue);
                                                                        product.ProductPhoto = null;
                                                                        db.tbe.Product.Add(product);
                                                                        db.tbe.SaveChanges();
                                                                        MessageBox.Show("Товар был успешно добавлен");
                                                                        this.Close();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните артикль");
            }
        }

        private void addProduct_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
