using BusinessObject.Model;
using System.Linq.Expressions;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            List<Member> members;
            try
            {
                var fstoreDB = new FStore_14_NguyenThiAnContext();
                members = fstoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public IEnumerable<Member> GetMembersByFilter(Expression<Func<Member, bool>> predicate)
        {
            List<Member> members;
            try
            {
                var fstoreDB = new FStore_14_NguyenThiAnContext();
                members = fstoreDB.Members.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member FindOne(Expression<Func<Member, bool>> predicate)
        {
            Member member;
            try
            {
                var fstoreDB = new FStore_14_NguyenThiAnContext();
                member = fstoreDB.Members.SingleOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddMember (Member member)
        {
            try
            {
               Member _member = FindOne(item => item.Email == member.Email);
                if(_member == null)
                {
                    var fstoreDB = new FStore_14_NguyenThiAnContext();
                    fstoreDB.Members.Add(member);
                    fstoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateMember(Member member)
        {
            try
            {
                Member _member = FindOne(item => item.MemberId == member.MemberId);
                if (_member != null)
                {
                    var fstoreDB = new FStore_14_NguyenThiAnContext();
                    fstoreDB.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    fstoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member did not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                Member _member = FindOne(item => item.MemberId == member.MemberId);
                if (_member != null)
                {
                    var fstoreDB = new FStore_14_NguyenThiAnContext();
                    fstoreDB.Members.Remove(member);
                    fstoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member did not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}