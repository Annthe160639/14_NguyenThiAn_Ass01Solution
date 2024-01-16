using BusinessObject.Model;
using DataAccess.Model;
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
    /// Interaction logic for AdminMember.xaml
    /// </summary>
    public partial class AdminMember : Window
    {
        private readonly IMemberRepository memberRepository;
        public AdminMember(IMemberRepository _memberRepository)
        {
            InitializeComponent();
            this.memberRepository = _memberRepository;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }
        private void LoadMembers()
        {
            listView.ItemsSource = memberRepository.GetMembers(null);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int? id = !String.IsNullOrEmpty(txtID.Text) ? int.Parse(txtID.Text) : null;
            string email = txtEmail.Text;
            string companyName = txtCompany.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;

            MemberFilter filter = new MemberFilter();
            filter.MemberId = id;
            filter.Email = email;
            filter.CompanyName = companyName;
            filter.City = city;
            filter.Country = country;

            listView.ItemsSource =  memberRepository.GetMembers(filter);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AdminMemberCreate adminMemberCreate = new AdminMemberCreate(memberRepository);
            adminMemberCreate.ShowDialog();            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = new Member();
                member.MemberId = int.Parse(txtID.Text);
                member.Email = txtEmail.Text;
                member.City = txtCity.Text;
                member.CompanyName = txtCompany.Text;
                member.Country = txtCountry.Text;
                member.Password = "1234";
                memberRepository.UpdateMember(member);
                LoadMembers();
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
                Member member = new Member();
                member.MemberId = int.Parse(txtID.Text);
                memberRepository.DeleteMember(member);
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }
    }
}
