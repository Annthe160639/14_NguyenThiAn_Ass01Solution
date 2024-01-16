using BusinessObject.Model;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        private readonly MainWindow main;
        public Home(MainWindow mainWindow, IOrderRepository _orderRepository, IMemberRepository _memberRepository)
        {
            InitializeComponent();
            Closing += Home_Closing;
            this.orderRepository = _orderRepository;
            this.memberRepository = _memberRepository;
            this.main = mainWindow;

        }

        private void Home_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Show();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            Member member = memberRepository.GetMembersByEmail(Session.Username);
            EditProfile editProfile = new EditProfile(member, memberRepository);
            editProfile.ShowDialog();
        }

        private void btnViewHistoryr_Click(object sender, RoutedEventArgs e)
        {
            Member member = memberRepository.GetMembersByEmail(Session.Username);
            OrderHistory editProfile = new OrderHistory(member, orderRepository);
            editProfile.ShowDialog();
        }
    }
}
