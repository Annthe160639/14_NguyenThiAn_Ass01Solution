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
    /// Interaction logic for OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : Window
    {
        private readonly Member member;
        private readonly IOrderRepository orderRepository;
        public OrderHistory(Member _member, IOrderRepository _iorderrepository)
        {
            InitializeComponent();
            this.member = _member;
            this.orderRepository = _iorderrepository;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderFilter orderFilter = new OrderFilter();
            orderFilter.MemberId = member.MemberId;
            listView.ItemsSource = orderRepository.FindAllBy(orderFilter);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? _startDate = startDate.SelectedDate == null ? null : startDate.SelectedDate.Value.Date;
            DateTime? _endDate = endDate.SelectedDate == null ? null : endDate.SelectedDate.Value.Date;
            OrderFilter orderFilter = new OrderFilter();
            orderFilter.StartDate = _startDate;
            orderFilter.EndDate = _endDate;
            orderFilter.MemberId = member.MemberId;
            listView.ItemsSource = orderRepository.FindAllBy(orderFilter);
        }
    }
}
