using BusinessObject.Model;
using DataAccess.Model;
using DataAccess.Repository;
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

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Window
    {
        private readonly IProductRepository productRepository;
        public AdminProduct(IProductRepository _iProductRepository)
        {
            InitializeComponent();
            this.productRepository = _iProductRepository;
        }


        public AdminProduct()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadedProducts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int? id = !String.IsNullOrEmpty(txtProductID.Text) ? int.Parse(txtProductID.Text) : null;
            string? name = txtProductName.Text;
            decimal? unitPrice = !String.IsNullOrEmpty(txtUnitPrice.Text) ? decimal.Parse(txtUnitPrice.Text) : null;
            int? unitsInStock = !String.IsNullOrEmpty(txtUnitsInStock.Text) ? int.Parse(txtUnitsInStock.Text) : null;

            ProductFilter productFilter = new ProductFilter();
            productFilter.ProductId = id;
            productFilter.ProductName = name;
            productFilter.UnitPrice = unitPrice;
            productFilter.UnitsInStock = unitsInStock;

            listView.ItemsSource = productRepository.FindAllBy(productFilter);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductId = int.Parse(txtProductID.Text);
                p.ProductName = txtProductName.Text;
                p.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                p.UnitsInStock = int.Parse(txtUnitsInStock.Text);
                p.CategoryId = int.Parse(txtCategoryID.Text);
                p.Weight = txtWeight.Text;
                productRepository.Add(p);   
                LoadedProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductId = int.Parse(txtProductID.Text);
                p.ProductName = txtProductName.Text;
                p.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                p.UnitsInStock = int.Parse(txtUnitsInStock.Text);
                p.CategoryId = int.Parse(txtCategoryID.Text);
                p.Weight = txtWeight.Text;
                productRepository.Update(p);
                LoadedProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductId = int.Parse(txtProductID.Text);
                productRepository.Remove(p);
                LoadedProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadedProducts();
        }
        private void LoadedProducts()
        {
            listView.ItemsSource = productRepository.List();
        }
    }
}
