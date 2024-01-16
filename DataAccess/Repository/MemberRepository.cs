using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member)
        {
            MemberDAO.Instance.AddMember(member);
        }

        public void DeleteMember(Member member)
        {
            MemberDAO.Instance.DeleteMember(member);
        }


        public Member GetMemberById(int id)
        {
            return (Member)MemberDAO.Instance.GetMembersByFilter(item => item.MemberId == id);
        }

        public IEnumerable<Member> GetMembers(MemberFilter filter)
        {
            if(filter != null)
            {
                return MemberDAO.Instance.GetMembersByFilter(member => (filter.MemberId == null || member.MemberId.Equals(filter.MemberId)) &&
                                                              (filter.Email == null || member.Email.ToLower().Contains(filter.Email.ToLower())) &&
                                                              (filter.CompanyName == null || member.CompanyName.ToLower().Contains(filter.CompanyName.ToLower())) &&
                                                              (filter.City == null || member.City.ToLower().Contains(filter.City.ToLower())) &&
                                                              (filter.Country == null || member.Country.ToLower().Contains(filter.Country.ToLower())));
            }
            return MemberDAO.Instance.GetMembers();
        }

        public Member GetMembersByEmail(string email)
        {
            return (Member)MemberDAO.Instance.FindOne(item => item.Email.Equals(email));
        }

        public Member GetMemberByEmailAndPassword(string email, string password)
        {
            return (Member)MemberDAO.Instance.FindOne(item => item.Email.Equals(email) 
                                                                        && item.Password.Equals(password));

        }

        public void UpdateMember(Member member)
        {
            MemberDAO.Instance.UpdateMember(member);
        }
    }
}
