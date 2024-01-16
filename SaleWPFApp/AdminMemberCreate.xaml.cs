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
    /// Interaction logic for AdminMemberCreate.xaml
    /// </summary>
    public partial class AdminMemberCreate : Window
    {
        private readonly IMemberRepository memberRepository;
        public AdminMemberCreate(IMemberRepository _imemberRepository)
        {
            InitializeComponent();
            this.memberRepository = _imemberRepository;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!pwbPassword.Password.Equals(pwbPassword2.Password))
                {
                    throw new Exception("Password is not correct.");
                }
                Member member = new Member();
                member.Email = txtEmail.Text;
                member.City = txtCity.Text;
                member.CompanyName = txtCompany.Text;
                member.Country = txtCountry.Text;
                member.Password = pwbPassword.Password;
                memberRepository.AddMember(member);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
