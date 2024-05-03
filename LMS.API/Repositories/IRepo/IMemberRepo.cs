using LMS.Shared.DataModel;

namespace LMS.API.Repositories
{
    public interface IMemberRepo
    {
        public List<Members> GetMembers();
        public Members GetMember(int MemberId);
        public Task<bool> DeleteMember(int MembersId);
        public Task<bool> AddOrEditMember(Members Members);
    }
}
