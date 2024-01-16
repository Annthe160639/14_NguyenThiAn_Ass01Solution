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
    /// Interaction logic for AdminOrder.xaml
    /// </summary>
    public partial class AdminOrder : Window
    {
        private IOrderRepository orderRepository;
        public AdminOrder(IOrderRepository _orderRepository)
        {
            InitializeComponent();
            this.orderRepository= _orderRepository;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderFilter orderFilter = new OrderFilter();
            orderFilter.StartDate = DateTime.Today;
            orderFilter.EndDate = DateTime.Today.AddDays(1);
            listView.ItemsSource = orderRepository.FindAllBy(orderFilter);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? _startDate = startDate.SelectedDate == null ? null : startDate.SelectedDate.Value.Date;
            DateTime? _endDate = endDate.SelectedDate == null ? null : endDate.SelectedDate.Value.Date;
            OrderFilter orderFilter = new OrderFilter();
            orderFilter.StartDate = _startDate;
            orderFilter.EndDate = _endDate;
            listView.ItemsSource = orderRepository.FindAllBy(orderFilter);
        }

    }
}
