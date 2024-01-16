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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        private readonly Member member;
        private readonly IMemberRepository memberRepository;
        public EditProfile(Member _member, IMemberRepository _imemberRepository)
        {
            InitializeComponent();
            this.member = _member;
            this.memberRepository = _imemberRepository;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = member.Email;
            txtCountry.Text = member.Country;
            txtCompany.Text = member.CompanyName;
            txtCity.Text = member.City;
            pwbPassword.Password= member.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Member m = member;
            m.Email= txtEmail.Text;
            m.City= txtCity.Text;
            m.Country= txtCountry.Text;
            m.CompanyName= txtCompany.Text;
            m.Password = pwbPassword.Password;
            try
            {
                memberRepository.UpdateMember(m);
                MessageBox.Show("Edit profile successfully.");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Edit profile fail");
            }
            Window_Loaded(sender, e);
        }
    }
}
