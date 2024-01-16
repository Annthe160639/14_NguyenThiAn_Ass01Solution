using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AdminManager.xaml
    /// </summary>
    public partial class AdminManager : Window
    {
        private readonly IProductRepository productRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IOrderRepository orderRepository;
        private readonly MainWindow mainWindow;
        public AdminManager(MainWindow _mainWindow, IProductRepository _productRepository, IMemberRepository _memberRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
            this.memberRepository = _memberRepository;
            this.orderRepository = _orderRepository;
            this.mainWindow = _mainWindow;
            Closing += AdminManager_Closing;
        }

        private void AdminManager_Closing(object? sender, CancelEventArgs e)
        {
            mainWindow.Show();
        }

        private void btnManageMember_Click(object sender, RoutedEventArgs e)
        {
            AdminMember adminMember = new AdminMember(memberRepository);
            adminMember.Show();
        }

        private void btnManageProduct_Click(object sender, RoutedEventArgs e)
        {
            AdminProduct adminProduct = new AdminProduct(productRepository);
            adminProduct.Show();
        }

        private void btnManageOrder_Click(object sender, RoutedEventArgs e)
        {
            AdminOrder adminOrder = new AdminOrder(orderRepository);
            adminOrder.Show();
        }
    }
}
