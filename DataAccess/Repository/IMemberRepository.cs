using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMembers(MemberFilter filter);
        public Member GetMemberById(int id);
        public Member GetMembersByEmail(string email);
        public Member GetMemberByEmailAndPassword(string email, string password);
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public void DeleteMember(Member member);
    }
}
