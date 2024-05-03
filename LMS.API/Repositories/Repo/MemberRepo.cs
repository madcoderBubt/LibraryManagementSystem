using LMS.API.Data;
using LMS.Shared.DataModel;

namespace LMS.API.Repositories.Repo
{
    internal class MemberRepo : IMemberRepo
    {
        private readonly AppDBContext _dbContext;

        public MemberRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> AddOrEditMember(Members Members)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMember(int MembersId)
        {
            throw new NotImplementedException();
        }

        public Members GetMember(int MemberId)
        {
            throw new NotImplementedException();
        }

        public List<Members> GetMembers()
        {
            throw new NotImplementedException();
        }
    }
}
